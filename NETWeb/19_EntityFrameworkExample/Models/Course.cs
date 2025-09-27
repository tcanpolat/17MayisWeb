using System.ComponentModel.DataAnnotations.Schema;

namespace _19_EntityFrameworkExample.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        // Foreign key property
        public int StudentId { get; set; }
        // Navigation Property
        public Student Student { get; set; }
    }
}
