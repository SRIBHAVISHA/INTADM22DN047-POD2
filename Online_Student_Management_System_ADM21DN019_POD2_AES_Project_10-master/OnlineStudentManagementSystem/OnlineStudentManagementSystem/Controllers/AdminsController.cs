using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class AdminsController : ControllerBase
    {

        
            private readonly IAdminService _adminService;

            public AdminsController(IAdminService adminService)
            {
                this._adminService = adminService;
            }

            [HttpGet]
            public async Task<IActionResult> Get()
            {
                var admin = await _adminService.Get();

                return Ok(admin);
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetAdmin(int id)
            {
                var item = await _adminService.GetById(id);

                if (item == null)
                    return NotFound();

                return Ok(item);
            }

        [HttpPost]
        public async Task<IActionResult> CreateAdmin(Admin admin)
        {
            if (ModelState.IsValid)
            {
                await _adminService.CreateAdmin(admin);

                return Ok(admin);
            }

            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteAdmin(int id)
            {
                var item = await _adminService.GetById(id);

                if (item == null)
                    return BadRequest();
            await _adminService.DeleteAdmin(id);

            return Ok(item);
            }
        }
    }

