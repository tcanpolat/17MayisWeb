using _17_AdoNetExample.DbServices.Abstract;
using _17_AdoNetExample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Diagnostics;

namespace _17_AdoNetExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDbService _dbService;

        public HomeController(IDbService dbService)
        {
            _dbService = dbService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddData()
        {
            string query = "INSERT INTO Student (FirstName,LastName,Age) VALUES ('Tahsin','Canpolat',33)";
            _dbService.ExecuteNonQuery(query);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult GetData()
        {
            string query = "SELECT FirstName,LastName,Age FROM Student";
            var data = _dbService.ExecuteReader(query);
            return View(data);
        }

        [HttpGet]
        public IActionResult GetCount()
        {
            string query = "SELECT COUNT(*) FROM Student";
            var count = _dbService.ExecuteScalar(query);
            return View(count);
        }

        [HttpPost]
        public IActionResult AddDataSecure([FromForm] Student model)
        {
            string query = "INSERT INTO Student (FirstName,LastName,Age) VALUES (@FirstName,@LastName,@Age)";

            SqlParameter[] parameters =
            {
                new SqlParameter("@FirstName",model.FirstName),
                new SqlParameter("@LastName",model.LastName),
                new SqlParameter("@Age",model.Age),
            };
            _dbService.ExecuteNonQuery(query, parameters);
            return RedirectToAction("Index");
        }

    }
}
