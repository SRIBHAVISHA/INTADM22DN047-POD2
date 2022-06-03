using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStudentManagementSystem.DTO;
using OnlineStudentManagementSystem.Models;
using OnlineStudentManagementSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStudentManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public StudentsController(IStudentService studentService, IMapper mapper)
        {
            this._studentService = studentService;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var students = await _studentService.Get();

            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            var item = await _studentService.GetById(id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent(StudentDTO studentDto)
        {
            if (ModelState.IsValid)
                            {
                var student = _mapper.Map<Student>(studentDto);
                await _studentService.CreateStudent(student);

                return Ok(student);
            }

            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };


        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, Student studentdto)
        {
            try
            {

                var student = await _studentService.GetById(id);

                if (student == null)
                {
                    return NotFound($"Student with Id ={id} not found");
                }

                if (id != studentdto.StudentId)
                {
                    return BadRequest("ID mismatch");
                }

                await _studentService.UpdateStudent(id, studentdto);

                return Ok(student);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var item = await _studentService.GetById(id);

            if (item == null)
                return BadRequest();
            await _studentService.DeleteStudent(id);


            return Ok(item);
        }
    }
}

