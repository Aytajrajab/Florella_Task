using Florella.DAL;
using Florella.Models;
using Florella.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Florella.Controllers
{
    public class BasketController : Controller
    {
        public AppDbContext _context { get; set; }
        public BasketController(AppDbContext contex)
        {
            _context = contex;
        }

        public async Task<IActionResult> AddToBasket(int id)
        {
            Product product = await _context.Products.FindAsync(id);
            List<BasketViewModel> basket;
            var basketItem = Request.Cookies["basket"];
            if (string.IsNullOrEmpty(basketItem)){
                basket = new List<BasketViewModel>();
            }
            else
            {
                basket = JsonConvert.DeserializeObject<List<BasketViewModel>>(basketItem);
            }

            var existProduct = basket.Find(p=>p.id == id);
            if (existProduct == null) 
            {
                BasketViewModel model = new BasketViewModel();
                model.id = existProduct.id;
                model.name = existProduct.name;
                model.image = existProduct.image;
                model.price = existProduct.price;
                model.CategoryId = existProduct.CategoryId;
                model.category = existProduct.category;
                basket.Add(model);
            }
            else
            {
                existProduct.count++;
            }
            basketItem = JsonConvert.SerializeObject(basket);
            Response.Cookies.Append("basket", basketItem);
            return RedirectToAction("Index","Home");
        }

        public async Task<IActionResult> GetBasket()
        {
            List<BasketViewModel> basket = JsonConvert.DeserializeObject<List<BasketViewModel>>(Request.Cookies["basket"]);

            foreach (var item in basket)
            {
                Product product = await _context.Products.FindAsync(item.id);
                if (product != null)
                {
                    continue;
                }
                item.price = product.Price;
                item.name = product.Name;
            }
            var json = JsonConvert.SerializeObject(basket);
            Response.Cookies.Append("basket", json);

            return Content(json);
        }

        public IActionResult BasketCount()
        {
            int basketCount = 0;
            var bsktItem = Request.Cookies["basket"];
            if (!string.IsNullOrEmpty(bsktItem))
            {
                foreach (var item in JsonConvert.DeserializeObject<List<BasketViewModel>>(bsktItem))
                {
                    basketCount += item.count;
                }
                return Ok(basketCount);
            }
            return Ok();
        }

    }
}
