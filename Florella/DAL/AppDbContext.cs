using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Florella.Models;
namespace Florella.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Section> Sections { get; set; }
        public DbSet<SectionImage> SectionImages { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Experts> Expert { get; set; }
        public DbSet<ExpertTitle> ExpertTitles { get; set; }
        public DbSet<Say> Says { get; set; }
        public DbSet<BlogTitle> BlogTitles { get; set; }
        public DbSet<BlogSection> BlogSections { get; set; }
    }
}
