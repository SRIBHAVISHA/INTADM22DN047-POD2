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
    public class AddressCodesController : ControllerBase

    {
        private readonly IAddressCodeService _addressCodeService;
        private readonly IMapper _mapper;



        public AddressCodesController(IAddressCodeService addressCodeService, IMapper mapper)
        {
            this._addressCodeService = addressCodeService;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var addressCodes = await _addressCodeService.Get();

            return Ok(addressCodes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAdressCode(int id)
        {
            var item = await _addressCodeService.GetById(id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }
       
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAddressCode(int id, AddressCode addressCodedto)
        {
            try
            {

                var addressCode = await _addressCodeService.GetById(id);

                if (addressCode == null)
                {
                    return NotFound($"AddressCode with Id ={id} not found");
                }

                if (id != addressCodedto.AddressCodeId)
                {
                    return BadRequest("ID mismatch");
                }

                await _addressCodeService.UpdateAddressCode(id, addressCodedto);

                return Ok(addressCode);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task <IActionResult> CreateAddressCode(AddressCodeDTO addressCodeDto)
        {
            if (ModelState.IsValid)
            {
                var addressCode = _mapper.Map<AddressCode>(addressCodeDto);

                await _addressCodeService.CreateAddressCode(addressCode);



                return Ok(addressCode);
            }

            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }
       
   


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddressCode(int id)
        {
            var item = await _addressCodeService.GetById(id);

            if (item == null)
                return BadRequest();
            await _addressCodeService.DeleteAddressCode(id);

            return Ok(item);
        }
    }
}
