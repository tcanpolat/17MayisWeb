using _06_HtmlHelpers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace _06_HtmlHelpers.Controllers
{
    public class HomeController : Controller
    {
       
        public IActionResult Index()
        {
            User model = new User()
            {
                CountryList = GetCountries()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Submit(User model)
        {
            User user = new User()
            {
                CountryList = GetCountries()
            };

            if (ModelState.IsValid) { // Modelin Data annotaions ile verilen kurallarý uygun mu?
                ViewBag.message = $"Name: {model.Name}, Age: {model.Age}, IsSubscribed: {model.IsSubscribed}, Gender: {model.Gender}, Country: {model.Gender}";
                return View("Result", model);
            
            }



            return View("Index",user);
        }

        public List<SelectListItem> GetCountries()
        {
            return new List<SelectListItem>
            {
                new SelectListItem{Value = "US" , Text = "United State"},
                new SelectListItem{Value = "CA" , Text = "Canada"},
                new SelectListItem{Value = "MX" , Text = "Mexico"},
            };
        }
    }
}
