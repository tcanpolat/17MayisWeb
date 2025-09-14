using _15_Filter_Operations.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _15_Filter_Operations.Controllers
{
    // Homecontrollerdaki her hangi bir action açýlsa bile authantication kontrolü yapýlýr.
    //[ServiceFilter(typeof(AuthrizationFilter))]
    public class HomeController : Controller
    {
        [ServiceFilter(typeof(ActionFilter))]
        public IActionResult Index()
        {
            return View();
        }

        [ServiceFilter(typeof(AuthrizationFilter))]
        public IActionResult Profile()
        {
            return View();
        }

        [ServiceFilter(typeof(ExceptionFilter))]
        public IActionResult SpecialAction()
        {
            throw new Exception("Bu bir test hatasýdýr.");
        }

        public IActionResult Page404()
        {
            return View();
        }


    }
}
