using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace _04_ViewBag_ViewData_TempData.Controllers
{
    public class HomeController : Controller
    {
        /* 
         Controller'dan View'e veri taþýmak için kullanýlan yöntemler
         1. ViewBag: Dinamik bir özellik olup. Controllerdan viewe veri taþýmak için kullanýlýr.
         2. ViewData: Sözlük(Dictonary) benzeri bir yapýdýr. ve controllerdan viewe veri taþýr.
         3. TempData: Geçici veri taþýmak için kullanýlýr ve iki sonuç(view-actionresult) arasýnda veri taþýmayý saðlar.       
         */
       
        public IActionResult Index()
        {
            // Viewbag dinamik özellikler alýr ve bunun sayesinde veri taþýr. Veri 1 sonuç (actionresult)
            // boyunca geçerlidir.
            ViewBag.ad = "Tahsin";
            ViewBag.sonuc = true;
            List<string> list = new List<string>();
            list.Add("Ali");
            ViewBag.liste = list;

            // ViewData, anahtar-deger (key-value) iliþkisiyle verileri tutar.  Veri 1 sonuç (actionresult)
            // boyunca geçerlidir.
            ViewData["soyad"] = "Canpolat"; // "soyad" deðeri keydir. ve keye göre çaðýrým yapýlýr.

            // TempData, geçici verileri taþýr ve iki sonuç (actionresult) boyunca geçerli olabilir.
            // TempData'da key-value iliþkisiyle tutulur.
            TempData["cinsiyet"] = "erkek"; // "cinsiyet" deðeri keydir. Ve keye göre çaðýrým yapýlýr.

            return View();
        }

        public IActionResult About()
        {
            ViewData["text"] = ViewData["soyad"]; // ViewData["soyad"] Indexte tanýmlý olduðu için tek view boyunca taþýnabilir. Burada kullanýlamaz!
            TempData["veri"] = TempData["cinsiyet"]; // Ýki action boyunca taþýnabilir.

            ViewBag.dersler = new SelectListItem[]
            {
                new SelectListItem {Text = "JS"},
                new SelectListItem {Text = "C#"},
                new SelectListItem {Text = "SQL"},
            };
            return View();
        }


       
    }
}
