using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace _04_ViewBag_ViewData_TempData.Controllers
{
    public class HomeController : Controller
    {
        /* 
         Controller'dan View'e veri ta��mak i�in kullan�lan y�ntemler
         1. ViewBag: Dinamik bir �zellik olup. Controllerdan viewe veri ta��mak i�in kullan�l�r.
         2. ViewData: S�zl�k(Dictonary) benzeri bir yap�d�r. ve controllerdan viewe veri ta��r.
         3. TempData: Ge�ici veri ta��mak i�in kullan�l�r ve iki sonu�(view-actionresult) aras�nda veri ta��may� sa�lar.       
         */
       
        public IActionResult Index()
        {
            // Viewbag dinamik �zellikler al�r ve bunun sayesinde veri ta��r. Veri 1 sonu� (actionresult)
            // boyunca ge�erlidir.
            ViewBag.ad = "Tahsin";
            ViewBag.sonuc = true;
            List<string> list = new List<string>();
            list.Add("Ali");
            ViewBag.liste = list;

            // ViewData, anahtar-deger (key-value) ili�kisiyle verileri tutar.  Veri 1 sonu� (actionresult)
            // boyunca ge�erlidir.
            ViewData["soyad"] = "Canpolat"; // "soyad" de�eri keydir. ve keye g�re �a��r�m yap�l�r.

            // TempData, ge�ici verileri ta��r ve iki sonu� (actionresult) boyunca ge�erli olabilir.
            // TempData'da key-value ili�kisiyle tutulur.
            TempData["cinsiyet"] = "erkek"; // "cinsiyet" de�eri keydir. Ve keye g�re �a��r�m yap�l�r.

            return View();
        }

        public IActionResult About()
        {
            ViewData["text"] = ViewData["soyad"]; // ViewData["soyad"] Indexte tan�ml� oldu�u i�in tek view boyunca ta��nabilir. Burada kullan�lamaz!
            TempData["veri"] = TempData["cinsiyet"]; // �ki action boyunca ta��nabilir.

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
