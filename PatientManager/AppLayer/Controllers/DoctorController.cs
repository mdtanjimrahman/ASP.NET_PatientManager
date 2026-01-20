using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        DoctorService service;

        public DoctorController(DoctorService service)
        {
            this.service = service;
        }

        // GET: api/Doctor/all
        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var data = service.GetAll();
            return Ok(data);
        }

        // GET: api/Doctor/get/{id}
        [HttpGet("get/{id}")]
        public IActionResult Get(int id)
        {
            var data = service.Get(id);
            if (data == null) 
                return NotFound();
            return Ok(data);
        }

        // POST: api/Doctor/create
        [HttpPost("create")]
        public IActionResult Create(DoctorDTO dto)
        {
            var result = service.Create(dto);
            if (!result) 
                return BadRequest("failed.");
            return Ok("Doctor info created ");
        }

        // PUT: api/Doctor/update
        [HttpPut("update")]
        public IActionResult Update(DoctorDTO dto)
        {
            var result = service.Update(dto);
            if (!result) 
                return BadRequest("Update failed.");
            return Ok("Doctor info updated");
        }

        // DELETE: api/Doctor/delete/{id}
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var result = service.Delete(id);
            if (!result) 
                return NotFound("Doctor not found");
            return Ok("Doctor info deleted");
        }

        // GET: api/Doctor/special/{specialization}
        [HttpGet("special/{specialization}")]
        public IActionResult GetBySpecialization(string specialization)
        {
            var data = service.GetBySpecialization(specialization);
            return Ok(data);
        }

        // GET: api/Doctor/email
        [HttpGet("email")]
        public IActionResult GetByEmail(string email)
        {
            var data = service.GetByEmail(email);
            if (data == null) 
                return NotFound();
            return Ok(data);
        }
    }
}
