using Florella.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Florella.ViewModels;

namespace Florella.ViewComponents
{
    public class SayViewComponent : ViewComponent
    {
        private AppDbContext _context { get; set; }
        public SayViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var say = _context.Says.ToList();
            ViewModelSectionSectionImage model = new ViewModelSectionSectionImage()
            {
                says = say
            };
            return View(model);
        }
    }
}
