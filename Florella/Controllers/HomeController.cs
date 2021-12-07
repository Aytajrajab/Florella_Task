using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Florella.DAL;
using Florella.ViewModels;



namespace Florella.Controllers
{
    public class HomeController : Controller
    {
        public AppDbContext _context { get; set; }
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var section = _context.Sections.FirstOrDefault();
            var sectionImage = _context.SectionImages.FirstOrDefault();

            ViewModelSectionSectionImage model = new ViewModelSectionSectionImage()
            {
                sectionImage = sectionImage,
                section = section,
            };
            return View(model);

        }
    }
}
