using _19_EntityFrameworkExample.Models;

namespace _19_EntityFrameworkExample.Extensions
{
    public static class StudentExtensions
    {
        // Öğrencileri yaş aralıklarına göre listeleyen method.

        public static IDictionary<string,List<Student>> GroupByAgeRange(this IEnumerable<Student> students)
        {
               return students
                .GroupBy(s =>
                {
                    if (s.Age<18) return "18 yaş altı";
                    if (s.Age<25) return "18-24";
                    if (s.Age <35) return "25-34";
                    return "35 yaş üstü";
                }).ToDictionary(s => s.Key, s => s.ToList());
        }
    }
}
