using _16_AutoMapper.Dtos;
using _16_AutoMapper.Models;
using AutoMapper;

namespace _16_AutoMapper.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        {
            // User => UserDto'ya dönüşümünü tanımlayacağız.
            // Userdaki FirstName LastName i FullName e mapleyeceğiz.
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}")).ReverseMap()
                .AfterMap((src, dest) =>
                {
                    var parts = src.FullName.Split(' ', 2);
                    dest.FirstName = parts[0];
                    dest.LastName = parts.Length > 1 ? parts[1] : "";
                });


            // ReverseMap => Maplemeyi terse çevirir. Yani UserDto'dan geleni User'a çevir demektir. Yada Userdan geleni UserDto'ya çevir demektir.
            // ReverserMap istemiyorsak aşağıdaki gibi mapleme yapılabilir.
            //CreateMap<UserDto, User>();
        
        }
    }
}
