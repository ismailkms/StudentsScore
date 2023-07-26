using AutoMapper;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DTOLayer.DTOs.CourseDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StudentsScore.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class CourseController : ControllerBase
    {
        CourseManager courseManager = new CourseManager(new EfCourseRepository());
        private readonly IMapper _mapper;

        public CourseController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult CourseList()
        {
            var values = courseManager.GetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CourseAdd(CourseAddDTO courseAddDTO)
        {
            Course course = _mapper.Map<Course>(courseAddDTO);
            courseManager.Add(course);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult CourseGetById(int id)
        {
            var course = courseManager.GetById(id);
            if (course == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(course);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult CourseDelete(int id)
        {
            var course = courseManager.GetById(id);
            if (course == null)
            {
                return NotFound();
            }
            else
            {
                courseManager.Delete(course);
                return Ok();
            }
        }

        [HttpPut]
        public IActionResult CourseUpdate(CourseUpdateDTO courseUpdateDTO)
        {
            Course course = _mapper.Map<Course>(courseUpdateDTO);
            var courseValue = courseManager.GetById(course.Id);
            if (courseValue == null)
            {
                return NotFound();
            }
            else
            {
                courseValue.CourseName = course.CourseName;
                courseManager.Update(courseValue);
                return Ok();
            }
        }
    }
}
