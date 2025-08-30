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
                Soyad = "T�rk",
                Yas = 27
            };

            Adres adres = new Adres()
            {
                Sehir = "�stanbul",
                AdresTanim = "Kad�k�y/Cafera�a"
            };

            // Homepage2 ye 2 modeli birden yollamak istiyorum.
            // ViewModel => Viewlerde kullanca��m�z modeller�n tan�m� yada modelleri tek bir yere toplamak i�in
            // kulland���m�z kavram.
            HomePageViewModel homePageViewModel = new HomePageViewModel();
            homePageViewModel.Adres = adres;
            homePageViewModel.Kisi = kisi;

            return View(homePageViewModel);
        }

       
    }
}
