using Florella.Models;
using System.Collections.Generic;

namespace Florella.ViewModels
{
    public class ViewModelSectionSectionImage
    {
        public Section section { get; set; }    
        public SectionImage sectionImage { get; set; }
        public List<Category> categories { get; set; }
        public List<Product> products { get; set; }
        public ExpertTitle expertTitles { get; set; }
        public List<Experts> experts { get; set; }
    }
}
