using _10_Models_Binding.Models;
using _10_Models_Binding.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _10_Models_Binding.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            Kisi kisi = new Kisi()
            {
                Ad = "Tahsin",
                Soyad = "Canpolat",
                Yas = 33
            };

            return View(kisi);
        }

        [HttpPost]
        public IActionResult Index(Kisi kisi)
        {
            return View(kisi);
        }

        public IActionResult HomePage2()
        {
            Kisi kisi = new Kisi()
            {
                Ad = "Erkan",
                Soyad = "Türk",
                Yas = 27
            };

            Adres adres = new Adres()
            {
                Sehir = "Ýstanbul",
                AdresTanim = "Kadýköy/Caferaða"
            };

            // Homepage2 ye 2 modeli birden yollamak istiyorum.
            // ViewModel => Viewlerde kullancaðýmýz modellerýn tanýmý yada modelleri tek bir yere toplamak için
            // kullandýðýmýz kavram.
            HomePageViewModel homePageViewModel = new HomePageViewModel();
            homePageViewModel.Adres = adres;
            homePageViewModel.Kisi = kisi;

            return View(homePageViewModel);
        }

       
    }
}
