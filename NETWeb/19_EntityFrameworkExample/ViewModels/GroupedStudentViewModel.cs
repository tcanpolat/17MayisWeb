using _19_EntityFrameworkExample.Models;

namespace _19_EntityFrameworkExample.ViewModels
{
    public class GroupedStudentViewModel
    {
        public string Department {get; set;}
        public List<Student> Students {get; set;}
    }
}
