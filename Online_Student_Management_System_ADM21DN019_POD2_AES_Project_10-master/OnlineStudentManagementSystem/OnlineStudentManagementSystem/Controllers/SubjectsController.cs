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
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectService _subjectService;
        private readonly IMapper _mapper;

        public SubjectsController(ISubjectService subjectService, IMapper mapper)
        {
            this._subjectService = subjectService;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var subject = await _subjectService.Get();

            return Ok(subject);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubject(int id)
        {
            var item = await _subjectService.GetById(id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubject(SubjectDTO subjectDto)
        {
            if (ModelState.IsValid)
            {
                var subject = _mapper.Map<Subject>(subjectDto);
                await _subjectService.CreateSubject(subject);



                return Ok(subject);
            }

            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSubject(int id, Subject subjectdto)
        {
            try
            {

                var subject = await _subjectService.GetById(id);

                if (subject == null)
                {
                    return NotFound($"Subject with Id ={id} not found");
                }

                if (id != subjectdto.SubjectId)
                {
                    return BadRequest("ID mismatch");
                }

                await _subjectService.UpdateSubject(id, subjectdto);

                return Ok(subject);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubject(int id)
        {
            var item = await _subjectService.GetById(id);

            if (item == null)
                return BadRequest();
            await _subjectService.DeleteSubject(id);

            return Ok(item);
        }
    }
}
