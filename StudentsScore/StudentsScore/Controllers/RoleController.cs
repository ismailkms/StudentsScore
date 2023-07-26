using AutoMapper;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DTOLayer.DTOs.RoleDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace StudentsScore.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class RoleController : ControllerBase
    {
        RoleManager roleManager = new RoleManager(new EfRoleRepository());
        private readonly IMapper _mapper;

        public RoleController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult RoleList()
        {
            var values = roleManager.GetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult RoleAdd(RoleAddDTO roleAddDTO)
        {
            Role role = _mapper.Map<Role>(roleAddDTO);
            roleManager.Add(role);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult RoleGetById(int id)
        {
            var role = roleManager.GetById(id);
            if (role == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(role);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult RoleDelete(int id)
        {
            var role = roleManager.GetById(id);
            if (role == null)
            {
                return NotFound();
            }
            else
            {
                roleManager.Delete(role);
                return Ok();
            }
        }

        [HttpPut]
        public IActionResult UserUpdate(RoleUpdateDTO roleUpdateDTO)
        {
            Role role = _mapper.Map<Role>(roleUpdateDTO);
            var roleValue = roleManager.GetById(role.Id);
            if (roleValue == null)
            {
                return NotFound();
            }
            else
            {
                roleValue.RoleName = role.RoleName;
                roleManager.Update(roleValue);
                return Ok();
            }
        }
    }
}
