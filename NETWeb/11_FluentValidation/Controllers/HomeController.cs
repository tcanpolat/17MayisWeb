using _11_FluentValidation.Models;
using _11_FluentValidation.ViewModels;
using FluentValidation;
using FluentValidation.Results;
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
            var model = new HomePageViewModel
            {
                Kisi = new Kisi(),
                Adres = new Adres()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Submit(HomePageViewModel model)
        {
            // modeli validate et
            ValidationResult result = _validator.Validate(model);

            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View("Index",model);
            }

            return View("Success",model);
        }

        public IActionResult Success(HomePageViewModel model)
        {
            return View(model);
        }

       
    }
}
