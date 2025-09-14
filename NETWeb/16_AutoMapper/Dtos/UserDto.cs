namespace _16_AutoMapper.Dtos
{
    /* 
     * DTO (Data Transfer Object) => Veri Taşıma Nesnesi
     Dto'lar nesnelerin verilerini bir yerden başka bir yere aktarmak için kullanılır. Genellikle bir veritabanın veri çekilirken veya bir web hizmetini veri yollarken kullanılır.
     Dto'lar verileri taşımak için basit veri yapılarından oluşur. Veriler, Dto içerisindeki alanlar veya özellikler olarak temsil edilir ve sadece veri aktarımı amacıyla kullanılır.    
     */
    public class UserDto
    {
        public int Id { get; set; }
        public string? FullName { get; set; } // FirstName + " " + LastName
        public string Email { get; set; }
    }
}
