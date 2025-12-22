using Front_To_Back_.Areas.AdminPanel.ViewModels.Products;
using Front_To_Back_.DAL;
using Front_To_Back_.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Area("AdminPanel")]
public class ProductController : Controller
{
    private readonly AppDbContext _context;
    public ProductController(AppDbContext context) => _context = context;

    
    public async Task<IActionResult> Index()
    {
        var products = await _context.Products
            .Include(p => p.Category)
            .Select(p => new GetProductVM
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                CategoryName = p.Category.Name,
                ImageURL = p.ProductImages.FirstOrDefault().ImageURL
            }).ToListAsync();

        return View(products); // Mütləq products siyahısını göndərin
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        ViewBag.Categories = await _context.Categories.Where(c => !c.IsDeleted).ToListAsync();
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ProductCreateVM productVM)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Categories = await _context.Categories.Where(c => !c.IsDeleted).ToListAsync();
            return View(productVM);
        }

        Product newProduct = new()
        {
            Name = productVM.Name,
            Price = productVM.Price,
            CategoryId = productVM.CategoryId
        };

        await _context.Products.AddAsync(newProduct);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}