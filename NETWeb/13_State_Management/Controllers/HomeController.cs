using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _13_State_Management.Controllers
{
    public class HomeController : Controller
    {
       

        public IActionResult Index()
        {
            // Session , Cookie
            /* 
                Session state, kullanýcýnýn oturum süresince verilerini saklamamýzý saðlar. Oturum sona erdiðinde bu veriler silinir.
                Session state özellikle kullanýcýnýn bilgilerinin saklanmasý gerektiðinde kullanýlýr. Fakat, þifre,kredi kartý gibi bilgiler saklanmamalýdýr.
                SUNUCU tarafýnda saklanýr !!
             
             */
            // Session veri yazma
            HttpContext.Session.SetString("UserName", "Tahsin Canpolat");

            // Session veri okuma
            var sessionUsername = HttpContext.Session.GetString("UserName");

            // Cookie state sunucu tarafýnda deðil, kullanýcý tarafýnda (clien side (tarayýcý)) tarafýnda saklanýr. Kullanýcý tarayýcýsý kapatýp açsa bile cookieler silinmez. Geçerlilik süresi boyunca yaþamýna devam eder. KESÝNLÝKLE kritik özel bilgiler cookiede tutulmaz.
            // 
            // Cookie oluþturma
            var cookieOptions = new CookieOptions
            {
                Expires = DateTime.Now.AddMinutes(30),
                HttpOnly = true,
                IsEssential = true,

            };

            // Set Cookie
            Response.Cookies.Append("Username", "Tahsin Canpolat");

            // Get Cookie
            var cookieUsername = Request.Cookies["Username"];

            // View'e ekleme
            ViewBag.SessionUserName = sessionUsername;
            ViewBag.cookieUsername = cookieUsername;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
