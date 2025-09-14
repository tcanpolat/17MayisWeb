using _16_AutoMapper.Dtos;
using _16_AutoMapper.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace _16_AutoMapper.Controllers
{
    public class UserController : Controller
    {
        private readonly IMapper _mapper;
        public UserController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            User user = new User()
            {
                Id = 1,
                FirstName = "Tahsin",
                LastName = "Canpolat",
                Email = "tahsincanpolat@gmail.com"
            };
            // Buradaki sorun user modelini yolladım fakat index sayfasında firstname lastname yok sadece fullname var.
            // UserDto userDto = user;

            var userDto = _mapper.Map<UserDto>(user);

            return View(userDto);
        }

        public IActionResult MappingTest()
        {
            var userDto = new UserDto()
            {
                Id = 1,
                FullName = "Tahsin Canpolat",
                Email = "tahsincanpolat@gmail.com"
            };
            var user = _mapper.Map<User>(userDto);
            return View(user);
        }
    }
}
