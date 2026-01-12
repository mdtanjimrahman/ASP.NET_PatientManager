using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        PrescriptionService service;

        public PrescriptionController(PrescriptionService service)
        {
            this.service = service;
        }

        // GET: api/Prescription/all
        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var data = service.GetAll();
            return Ok(data);
        }

        // GET: api/Prescription/get/{id}
        [HttpGet("get/{id}")]
        public IActionResult Get(int id)
        {
            var data = service.Get(id);
            if (data == null) 
                return NotFound();
            return Ok(data);
        }

        // POST: api/Prescription/create
        [HttpPost("create")]
        public IActionResult Create(PrescriptionDTO dto)
        {
            var result = service.Create(dto);
            if (!result) 
                return BadRequest("Failed.");
            return Ok("Prescription created");
        }

        // PUT: api/Prescription/update
        [HttpPut("update")]
        public IActionResult Update(PrescriptionDTO dto)
        {
            var result = service.Update(dto);
            if (!result) return BadRequest("Update failed.");
            return Ok("Prescription updated successfully.");
        }

        // DELETE: api/Prescription/delete/{id}
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var result = service.Delete(id);
            if (!result) return NotFound("Not found.");
            return Ok("Prescription deleted");
        }

        // GET: api/Prescription/by-patient/{patientId}
        [HttpGet("by-patient/{patientId}")]
        public IActionResult GetByPatient(int patientId)
        {
            var data = service.GetByPatient(patientId);
            return Ok(data);
        }

        // GET: api/Prescription/by-doctor/{doctorId}
        [HttpGet("by-doctor/{doctorId}")]
        public IActionResult GetByDoctor(int doctorId)
        {
            var data = service.GetByDoctor(doctorId);
            return Ok(data);
        }
    }
}
