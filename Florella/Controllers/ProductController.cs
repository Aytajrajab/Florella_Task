using Florella.DAL;
using Florella.Models;
using Florella.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<IActionResult> Search(string searchedStr)
        {
            if (string.IsNullOrEmpty(searchedStr))
            {
                return PartialView("_ProductSearchPartial", new List<Product>());
            }
            List<Product> products = await _context.Products.Where(p => p.Name.ToLower().Contains(searchedStr.ToLower())).ToListAsync();
            return PartialView("_ProductSearchPartial", products);
        }

    }
}
