using Flamixk.DAL;
using Flamixk.Models;
using Flamixk.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Flamixk.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
           _context = context;
        }


        public async Task<IActionResult> Index()
        {
            List<Product> products = await _context.Products.ToListAsync();
            if(products == null ) return NotFound();
            HomeVM homeVM = new HomeVM
            {
              Products = products
            };
            return View(homeVM);
        }

        
    }
}