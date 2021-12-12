using Florella.DAL;
using Florella.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Florella.Controllers
{
    public class ProductController : Controller
    {
        private AppDbContext _context;
        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var products = _context.Products.Take(4).Include(p => p.Category).ToList();
            ViewBag.SkipCount = products.Count;
            return View(new ProductIndexViewModel { Products = products });
        }

    }
}
