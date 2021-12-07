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
    }
}
