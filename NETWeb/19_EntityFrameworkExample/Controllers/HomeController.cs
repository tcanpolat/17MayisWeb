using _19_EntityFrameworkExample.Data;
using _19_EntityFrameworkExample.Extensions;
using _19_EntityFrameworkExample.Models;
using _19_EntityFrameworkExample.ViewModels;
using EFCore.BulkExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace _19_EntityFrameworkExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly SchoolContext _context;
        public HomeController(SchoolContext context)
        {
            _context = context;
        }

        // Anasayfa için tüm öðrencileri listeleyen aksiyon
        public IActionResult Index()
        {
            // DB den tüm öðrencileri al
            var students = _context.Students.ToList();
            return View(students);
        }

        // Belirli bir öðrenciye týkladýðýmda detaylarýný görebildiðim aksiyon
        public IActionResult Details(int id)
        {
            // DB den ID'ye göre öðrenci bul
            var student = _context.Students.Find(id);

            if(student is null)
            {
                return NotFound();
            }
            
            return View(student);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Age,Department")] Student student)
        {
            if (ModelState.IsValid)
            {
                // model geçerliyse öðrenciyi ekle
                _context.Add(student);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // Belirli bir öðrenciye týkladýðýmda düzenleyebildiðim aksiyon
        public IActionResult Edit(int id)
        {
            // DB den ID'ye göre öðrenci bul
            var student = _context.Students.Find(id);

            if (student is null)
            {
                return NotFound();
            }

            return View(student);
        }

        //öðrenci düzenlendikten sonra dbye kaydedilme aksiyonu
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Age,Department")] Student student)
        {
          

            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException err)
                {
                    // Güncelleme sýrasýnda bir hata oluþursa
                    if (!StudentExists(student.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw err;
                    }

                    
                }
                return RedirectToAction("Index");
            }

            return View(student);
        }

        public bool StudentExists(int id)
        {
            return _context.Students.Any(s => s.Id == id);
        }

        // Belirli bir öðrenciye týkladýðýmda silebildiðim aksiyon
        public IActionResult Delete(int id)
        {
            // DB den ID'ye göre öðrenci bul
            var student = _context.Students.Find(id);

            if (student is null)
            {
                return NotFound();
            }
            // Silme formunu göster
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // Id ye göre öðrenciyi bul
            var student = _context.Students.Find(id);
            if (student != null) {
                // bulduðu öðrenciyi db tablosundan sil
                _context.Students.Remove(student);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        // Query Syntax => Sorgu söz dizimi
        public IActionResult QuerySyntax()
        {
            var students = (from s in _context.Students
                            where s.Age > 18
                            select s).ToList();
            // yaþý 18 den büyük olan öðrencilerin listesini indexe gönder
            return View("Index",students);
                            
        }

        // Method Syntax => Method söz dizimi ile Linq sorgularý kullanarak filtreleme yapabiliriz.
        public IActionResult MethodSyntax()
        {
            var students = _context.Students
                            .Where(student => student.Age < 18)
                            .ToList();
            // yaþý 18 den küçük olan öðrencilerin listesini indexe gönder
            return View("Index", students);

        }

        // Öðrenciler ve Dersler birleþtir.
        public IActionResult Join()
        {
            var studentCourses = (from student in _context.Students
                                  join course in _context.Courses on
                                  student.Id equals course.StudentId
                                  select new
                                  {
                                      StudentName = student.Name,
                                      CourseTitle = course.Title
                                  }).ToList();

            // Join Sayfasýna kurslar ve öðrencileri tek bir tablo gibi yolla
            return View(studentCourses);
        }

        public IActionResult GroupedByDepartment()
        {
            var groupedStudents = _context.Students
                .GroupBy(s => s.Department)
                .Select(g => new GroupedStudentViewModel
                {
                    Department = g.Key,
                    Students = g.ToList()
                }).ToList();

            return View(groupedStudents);
        }

        // Bazý db iþleri için özel methodlar yazmamýz gerekebilir. Bunlara custom extension
        // method diyoruz.
        // Öðrencileri yaþ aralýðýna göre gruplayan method.
        public IActionResult CustomExtensionMethod()
        {
            var students = _context.Students.ToList();
            var groupedStudentsByAge = students.GroupByAgeRange();
            return View(groupedStudentsByAge);
        }

        public IActionResult GetStudentsByDepartment()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetStudentsByDepartment(string department)
        {
            var students = _context.Students
                            .FromSqlInterpolated($"EXEC GetStudentsByDepartment {department}")
                            .ToList();

            ViewData["Students"] = students;
            return View();
        }

        public IActionResult RawSql()
        {
            var students = _context.Students
                            .FromSqlRaw("select * from Students where Age > 18")
                            .ToList();
            return View("Index", students);
        }

        [HttpPost("Transaction")]
        public IActionResult AddStudentsByTransaction([FromBody] List<Student> students)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                _context.Students.AddRange(students);
                _context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                return StatusCode(500, "Öðrenciler eklenirken bir hata oluþtu");
            }

            return Ok();
        }

        public IActionResult BulkInsert()
        {
            var stundets = new List<Student>
            {
                new Student { Name = "Samet", Age = 22, Department = "Yazýlým" },
                new Student { Name = "Melih", Age = 23, Department = "Elektrik" },
                new Student { Name = "Efe", Age = 25, Department = "Elektronik" }

            };

            _context.BulkInsert(stundets);

            return RedirectToAction("Index");
        }
    }
}
