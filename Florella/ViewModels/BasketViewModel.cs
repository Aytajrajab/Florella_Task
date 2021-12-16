using Florella.Models;

namespace Florella.ViewModels
{
    public class BasketViewModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public double price { get; set; }
        public int CategoryId { get; set; }
        public Category category { get; set; }
        public int count { get; set; }
    }
}
