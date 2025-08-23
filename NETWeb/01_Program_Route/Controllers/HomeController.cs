using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace _01_Program_Route.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult AboutDetail(int id) { 
            ViewBag.Id = id;    
            return View();
        }

    }
}
