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
    public class SubjectReportCardsController : ControllerBase
    {
        private readonly ISubjectReportCardService _subjectReportCardService;
        private readonly IMapper _mapper;

        public SubjectReportCardsController(ISubjectReportCardService subjectReportCardService, IMapper mapper)
        {
            this._subjectReportCardService = subjectReportCardService;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var subjectReportCard = await _subjectReportCardService.Get();

            return Ok(subjectReportCard);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubjectEnrollment(int id)
        {
            var item = await _subjectReportCardService.GetById(id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpPost]
        public async Task  <IActionResult> CreateSujectReportCard(SubjectReportCardDTO subjectReportCardDto)
        {
            if (ModelState.IsValid)
            {
                var subjectReportCard = _mapper.Map<SubjectReportCard>(subjectReportCardDto);
                await _subjectReportCardService.CreateSubjectReportCard(subjectReportCard);


                return Ok(subjectReportCard);
            }

            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };

            
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSubjectReportCard(int id, SubjectReportCard subjectReportCarddto)
        {
            try
            {

                var subjectReportCard = await _subjectReportCardService.GetById(id);

                if (subjectReportCard == null)
                {
                    return NotFound($"Course with Id ={id} not found");
                }

                if (id != subjectReportCarddto.SubjectReportCardId)
                {
                    return BadRequest("ID mismatch");
                }

                await _subjectReportCardService.UpdateSubjectReportCard(id, subjectReportCarddto);

                return Ok(subjectReportCard);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubjectReportCard(int id)
        {
            var item = await _subjectReportCardService.GetById(id);

            if (item == null)
                return BadRequest();

            return Ok(item);
        }
    }
}

