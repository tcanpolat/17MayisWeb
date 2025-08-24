using _05_ModelsExample.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _05_ModelsExample.Controllers
{
    public class HomeController : Controller
    {
       
        public IActionResult Index()
        {
            User user = new User()
            {
                Name = "Tahsin",
                Surname = "Canpolat",
                Age = 33
            };

            ViewBag.User = user; // Viewbag ile modeli yollama

            return View(user); // Modeli direkt olarak viewe yollama
        }

        public IActionResult ProductPage()
        {
            Product product1 = new Product()
            {
                Id = 1,
                Name = "Telefon",
                Description = "Iphone 16",
                Price = 99000
            };
            Product product2 = new Product()
            {
                Id = 2,
                Name = "Gýda",
                Description = "Ekmek",
                Price = 15
            };

            List<Product> productList = new List<Product>()
            {
                product1,
                product2
            };
                
            ViewBag.ProductList = productList;
            return View();
        }

       
    }
}
