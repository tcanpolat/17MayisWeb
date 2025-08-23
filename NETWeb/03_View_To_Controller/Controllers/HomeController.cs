using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _03_View_To_Controller.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet] // => Actionlara yada controllerlara attribute verilebiliyor. HttpGet => Sayfan�n get olarak �al��t���n� g�sterir. E�er bir actionresulta get,post,delete,put,patch gibi attribute vermezsek default olarak get gibi �al���r.
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Index(string kisiler,string ad,bool onay)
        {
            var k1 = kisiler;
            var a1 = ad;
            var o1 = onay;

            return View();
        }
        [HttpPost]
        public IActionResult KisiGonder(string kisiler, string ad, bool onay)
        {
            var k1 = kisiler;
            var a1 = ad;
            var o1 = onay;

            return Redirect("Index");
        }



    }
}
