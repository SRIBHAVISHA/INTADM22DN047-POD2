using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineStudentManagementSystem.DTO;
using OnlineStudentManagementSystem.Models;
using OnlineStudentManagementSystem.Services;
using System;
using System.Threading.Tasks;

namespace OnlineStudentManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;
        private readonly IMapper _mapper;

        public CoursesController(ICourseService courseService, IMapper mapper)
        {
            this._courseService = courseService;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var addressCodes = await _courseService.Get();

            return Ok(addressCodes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAdressCode(int id)
        {
            var item = await _courseService.GetById(id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourse(CourseDTO courseDto)
        {
            if (ModelState.IsValid)
            {
         
                var course= _mapper.Map<Course>(courseDto);

                await _courseService.CreateCourse(course);


                return Ok(course);
            }

            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(int id, Course coursedto)
        {
            try
            {

                var course = await _courseService.GetById(id);

                if (course == null)
                {
                    return NotFound($"Course with Id ={id} not found");
                }

                if (id != coursedto.CourseId)
                {
                    return BadRequest("ID mismatch");
                }

                await _courseService.UpdateCourse(id, coursedto);

                return Ok(course);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var item = await _courseService.GetById(id);

            if (item == null)
                return BadRequest();
            await _courseService.DeleteCourse(id);

            return Ok(item);
        }
    }
}
