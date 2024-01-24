using Flamixk.Areas.Admin.ViewModels;
using Flamixk.DAL;
using Flamixk.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Flamixk.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ProductController(AppDbContext context,IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            List<Product> products = await _context.Products.ToListAsync();
            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductVM productVM)
        {
            if (!ModelState.IsValid) return View();
            bool result = await _context.Products.AnyAsync(p=>p.Name == productVM.Name);
            if (result)
            {
                ModelState.AddModelError("Name", "Bu adda name movcuddur");
                return View(productVM);
            }
            Product product = new Product
            {
                Name = productVM.Name,
                Description = productVM.Description,
                Icon = productVM.Icon,
            };
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index","Home");

        }
    }
}
