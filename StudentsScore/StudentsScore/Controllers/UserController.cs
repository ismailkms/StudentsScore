using AutoMapper;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DTOLayer.DTOs.UserDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StudentsScore.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "Admin")]

    public class UserController : ControllerBase
    {
        UserManager userManager = new UserManager(new EfUserRepository());
        private readonly IMapper _mapper;

        public UserController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult UserList()
        {
            var values = userManager.GetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult UserAdd(UserAddDTO userAddDTO)
        {
            User user=_mapper.Map<User>(userAddDTO);
            userManager.Add(user);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult UserGetById(int id)
        {
            var user = userManager.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(user);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult UserDelete(int id)
        {
            var user = userManager.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                userManager.Delete(user);
                return Ok();
            }
        }

        [HttpPut]
        public IActionResult UserUpdate(UserUpdateDTO userUpdateDTO)
        {
            User user = _mapper.Map<User>(userUpdateDTO);
            var userValue = userManager.GetById(user.Id);
            if (userValue == null)
            {
                return NotFound();
            }
            else
            {
                userValue.NameSurname = user.NameSurname;
                userValue.Username = user.Username;
                userValue.Password = user.Password;
                userValue.RoleId= user.RoleId;
                userManager.Update(userValue);
                return Ok();
            }
        }
    }
}
