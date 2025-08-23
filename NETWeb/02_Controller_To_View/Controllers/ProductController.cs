using Microsoft.AspNetCore.Mvc;

namespace _02_Controller_To_View.Controllers
{
    public class ProductController : Controller
    {
        // IActionResult => Geriye bir  view yada view parçacığı döndüreceğini söyler.
        public IActionResult Index()
        {
            var products = new List<string> { "Ürün 1", "Ürün 2", "Ürün 3" };
            // Veriyi viewdata olarak yollama
            ViewData["products"] = products;
            return View();
        }

        // Belirli ürünlerin detayını gösteren actionresult
        public IActionResult Details(int id) 
        {

            var product = $"Ürün {id} Detayları";
            ViewData["productDetail"] = product;
            return View();
        }
    }
}
