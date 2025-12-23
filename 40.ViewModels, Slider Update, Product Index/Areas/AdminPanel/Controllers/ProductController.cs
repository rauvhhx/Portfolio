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
            .Include(p => p.ProductImages)
            .Select(p => new GetProductVM
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                CategoryName = p.Category.Name,
                ImageURL = p.ProductImages.FirstOrDefault(pi => pi.IsPrimary == true) != null
                           ? p.ProductImages.FirstOrDefault(pi => pi.IsPrimary == true).ImageURL
                           : "default-image.jpg" 
            }).ToListAsync();

        return View(products);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        CreateProductVM createProductVM = new CreateProductVM()
        {
            Categories = await _context.Categories.ToListAsync(),
        };
        return View(createProductVM);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductVM createProductVM)
    {
        createProductVM.Categories = await _context.Categories.ToListAsync();

        if (!ModelState.IsValid)
        {
            return View(createProductVM);
        }

        bool existCategory = createProductVM.Categories.Any(c => c.Id == createProductVM.CategoryId);
        if (!existCategory)
        {
            ModelState.AddModelError(nameof(CreateProductVM.CategoryId), "Category does not exist!");
            return View(createProductVM);
        }

        Product product = new()
        {
            Name = createProductVM.Name,
            Price = createProductVM.Price,
            Description = createProductVM.Description,
            SKU = createProductVM.SKU,
            CategoryId = createProductVM.CategoryId,
        };

        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));

    }

    [HttpGet]
    public async Task<IActionResult> Update(int? id)
    {
        if (id == null || id <= 0) return BadRequest();

        if (!ModelState.IsValid)
        {
            return View();
        }

        Product existedProduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

        if (existedProduct == null) return NotFound();

        UpdateProductVM updateProductVM = new()
        {
            Name = existedProduct.Name,
            Price = existedProduct.Price,
            Description = existedProduct.Description,
            SKU = existedProduct.SKU,
            CategoryId = existedProduct.CategoryId,
            Categories = await _context.Categories.ToListAsync()
        };

        return View(updateProductVM);
    }
    [HttpPost]
    [HttpPost]
    public async Task<IActionResult> Update(int? id, UpdateProductVM updateProductVM)
    {
        if (id == null || id <= 0) return BadRequest();

        updateProductVM.Categories = await _context.Categories.ToListAsync();

        if (!ModelState.IsValid)
        {
            return View(updateProductVM);
        }

        Product existproduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
        if (existproduct == null) return NotFound();

        bool existCategory = updateProductVM.Categories.Any(c => c.Id == updateProductVM.CategoryId);
        if (!existCategory)
        {
            ModelState.AddModelError("CategoryId", "Category tapılmadı");
            return View(updateProductVM);
        }

        existproduct.Name = updateProductVM.Name;
        existproduct.Price = updateProductVM.Price;
        existproduct.Description = updateProductVM.Description;
        existproduct.SKU = updateProductVM.SKU;
        existproduct.CategoryId = updateProductVM.CategoryId;

        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

}