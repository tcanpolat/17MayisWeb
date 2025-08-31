using _12_Dependency_Injection.Models;
using _12_Dependency_Injection.Services.Abstract;

namespace _12_Dependency_Injection.Services.Concrete
{
    public class MyService : IMyService
    {
        public List<Student> GetStudents()
        {
           return new List<Student>
           {
               new Student() {Id = 1, Name = "Tahsin",Age = 34 },
               new Student() {Id = 2, Name = "Ali",Age = 23 },
               new Student() {Id = 3, Name = "Ahmet",Age = 14 }
           };
        }
    }
}
