using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicationController : ControllerBase
    {
        MedicationService service;

        public MedicationController(MedicationService service)
        {
            this.service = service;
        }

        // GET: api/Medication/all
        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var data = service.GetAll();
            return Ok(data);
        }

        // GET: api/Medication/get/{id}
        [HttpGet("get/{id}")]
        public IActionResult Get(int id)
        {
            var data = service.Get(id);
            if (data == null) 
                return NotFound();
            return Ok(data);
        }

        // POST: api/Medication/create
        [HttpPost("create")]
        public IActionResult Create(MedicationDTO dto)
        {
            var result = service.Create(dto);
            if (!result) 
                return BadRequest("failed.");
            return Ok("Medication report created");
        }

        // PUT: api/Medication/update
        [HttpPut("update")]
        public IActionResult Update(MedicationDTO dto)
        {
            var result = service.Update(dto);
            if (!result) 
                return BadRequest("Update failed.");
            return Ok("Medication info updated");
        }

        // DELETE: api/Medication/delete/{id}
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var result = service.Delete(id);
            if (!result) 
                return NotFound("Not found");
            return Ok("Medication info deleted");
        }

        // GET: api/Medication/by-presc/{prescriptionId}
        [HttpGet("by-presc/{prescriptionId}")]
        public IActionResult GetByPrescription(int prescriptionId)
        {
            var data = service.GetByPrescription(prescriptionId);
            return Ok(data);
        }

        // GET: api/Medication/by-name/{name}
        [HttpGet("by-name/{name}")]
        public IActionResult GetByName(string name)
        {
            var data = service.GetByName(name);
            return Ok(data);
        }
    }
}
