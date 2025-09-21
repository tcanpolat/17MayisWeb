using Microsoft.AspNetCore.Mvc;

namespace _18_DapperExample.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
