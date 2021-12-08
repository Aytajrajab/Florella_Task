﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Florella.DAL;
using Florella.ViewModels;
using Microsoft.EntityFrameworkCore;

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
            var products = _context.Products.Include(p => p.Category).OrderBy(p => p.Id).ToList();
            var categories = _context.Categories.ToList();
            var experts = _context.Expert.ToList();
            var expertTitles = _context.ExpertTitles.First();

            ViewModelSectionSectionImage model = new ViewModelSectionSectionImage()
            {
                sectionImage = sectionImage,
                section = section,
                products = products,
                categories = categories,
                expertTitles = expertTitles,
                experts = experts
            };
            return View(model);

        }
    }
}
