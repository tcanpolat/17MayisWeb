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
                Session state, kullan�c�n�n oturum s�resince verilerini saklamam�z� sa�lar. Oturum sona erdi�inde bu veriler silinir.
                Session state �zellikle kullan�c�n�n bilgilerinin saklanmas� gerekti�inde kullan�l�r. Fakat, �ifre,kredi kart� gibi bilgiler saklanmamal�d�r.
                SUNUCU taraf�nda saklan�r !!
             
             */
            // Session veri yazma
            HttpContext.Session.SetString("UserName", "Tahsin Canpolat");

            // Session veri okuma
            var sessionUsername = HttpContext.Session.GetString("UserName");

            // Cookie state sunucu taraf�nda de�il, kullan�c� taraf�nda (clien side (taray�c�)) taraf�nda saklan�r. Kullan�c� taray�c�s� kapat�p a�sa bile cookieler silinmez. Ge�erlilik s�resi boyunca ya�am�na devam eder. KES�NL�KLE kritik �zel bilgiler cookiede tutulmaz.
            // 
            // Cookie olu�turma
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
