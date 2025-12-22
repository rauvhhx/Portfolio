using Front_To_Back_.Areas.AdminPanel.ViewModels;
using Front_To_Back_.Areas.AdminPanel.ViewModels.Sliders;
using Front_To_Back_.DAL;
using Front_To_Back_.Models;
using Front_To_Back_.Utilities.Enums;
using Front_To_Back_.Utilities.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Front_To_Back_.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class SliderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SliderController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            List<Slider> sliders = await _context.Sliders.ToListAsync();

            return View(sliders);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SliderCreateVM sliderCreateVM)
        {
            if (!ModelState.IsValid) return View();


            if (!sliderCreateVM.Photo.ValidatorType("image/"))
            {
                ModelState.AddModelError("Photo", "File type is incorrect!");
                return View();
            }

            if (!sliderCreateVM.Photo.ValidatorSize(FileSize.MB, sliderCreateVM.Photo.Length))
            {
                ModelState.AddModelError("Photo", "File size must be less than 2 mb");
                return View();
            }

            Slider slider = new()
            {
                Title = sliderCreateVM.Title,
                SubTitle = sliderCreateVM.SubTitle,
                Description = sliderCreateVM.Description,
                Order = sliderCreateVM.Order,
                ImageURL = await sliderCreateVM.Photo.CreateFileAsync(_env.WebRootPath, "assets", "Images", "website-images")
            };


            await _context.Sliders.AddAsync(slider);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id) 
        {
            if (id is null || id < 1) return BadRequest();

            Slider slider = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == id);

            if (slider == null) return NotFound();

            SliderUpdateVM sliderUpdateVM = new()
            {
                Title = slider.Title,
                SubTitle = slider.SubTitle,
                Description = slider.Description,
                Order = slider.Order,
                ImageURL =slider.ImageURL
            };



            return View(sliderUpdateVM);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int? id, SliderUpdateVM sliderUpdateVM)
        {
            if (id is null || id < 1) return BadRequest();

            //Slider slider = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == id);

            //if (slider == null) return NotFound();

            //sliderUpdateVM.ImageURL=slider.ImageURL;

            if (!ModelState.IsValid) return View(sliderUpdateVM);

            Slider dbSlider = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == id);

            if (dbSlider == null) return NotFound();

            if (sliderUpdateVM.Photo is not null)
            {
                if (!sliderUpdateVM.Photo.ValidatorType("image/"))
                {
                    ModelState.AddModelError("Photo", "File type is incorrect!");
                    return View(sliderUpdateVM);
                }

                if (!sliderUpdateVM.Photo.ValidatorSize(FileSize.MB, sliderUpdateVM.Photo.Length))
                {
                    ModelState.AddModelError("Photo", "File size must be less than 2 mb");
                    return View(sliderUpdateVM);
                }

                string filename = await sliderUpdateVM.Photo.CreateFileAsync(_env.WebRootPath, "assests", "images", "website-images");

                sliderUpdateVM.ImageURL.DeleteFile(_env.WebRootPath, "assests", "images", "website-images");

                sliderUpdateVM.ImageURL = filename;
            }

            dbSlider.Title = sliderUpdateVM.Title;
            dbSlider.Description = sliderUpdateVM.Description;
            dbSlider.SubTitle = sliderUpdateVM.SubTitle;
            dbSlider.Order = sliderUpdateVM.Order;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
                

        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null || id < 1) return BadRequest();

            Slider slider  = await _context.Sliders.FirstOrDefaultAsync(s=>s.Id == id);

            if (slider == null) return NotFound();

            slider.ImageURL.DeleteFile(_env.WebRootPath, "assets", "images", "website-images");

            _context.Sliders.Remove(slider);

            await _context.SaveChangesAsync(); 

            return RedirectToAction(nameof(Index));
      
        }
        public async Task<IActionResult> Detail(int? id)
        {
            if (id is null || id < 1) return BadRequest();

            Slider slider = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == id);

            if (slider is null) return NotFound();

            return View(slider);
        }


    }
}
