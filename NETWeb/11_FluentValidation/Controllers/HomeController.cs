using _11_FluentValidation.Models;
using _11_FluentValidation.ViewModels;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _11_FluentValidation.Controllers
{
    public class HomeController : Controller
    {

        private readonly IValidator<HomePageViewModel> _validator;

        public HomeController(IValidator<HomePageViewModel> validator)
        {
            _validator = validator;
        }

        public IActionResult Index()
        {   
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

       
    }
}
