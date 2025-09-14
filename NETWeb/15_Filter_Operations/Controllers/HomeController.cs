using _15_Filter_Operations.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _15_Filter_Operations.Controllers
{
    // Homecontrollerdaki her hangi bir action a��lsa bile authantication kontrol� yap�l�r.
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
            throw new Exception("Bu bir test hatas�d�r.");
        }

        public IActionResult Page404()
        {
            return View();
        }


    }
}
