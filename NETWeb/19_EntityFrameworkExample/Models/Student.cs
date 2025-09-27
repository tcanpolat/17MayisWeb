﻿namespace _19_EntityFrameworkExample.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Department { get; set; }
        // Öğrencinin aldığı dersler, zorunlu olmamyan bir ilişki
        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
