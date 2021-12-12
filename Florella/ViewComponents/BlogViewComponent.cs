using Florella.DAL;
using Florella.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Florella.ViewComponents
{
    public class BlogViewComponent : ViewComponent
    {
        private AppDbContext _context { get; set; }
        public BlogViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var blogTitle = _context.BlogTitles.First();
            var blogSection = _context.BlogSections.ToList();

            ViewModelSectionSectionImage model = new ViewModelSectionSectionImage()
            {
                blogTitle = blogTitle,
                blogSections = blogSection
            };
            return View(model);
        }
    }
}
