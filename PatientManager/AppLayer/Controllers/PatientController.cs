using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        PatientService service;
        PatientReportService s;

        public PatientController(PatientService service, PatientReportService s)
        {
            this.service = service;
            this.s = s;
        }

        // GET: api/Patient/all
        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var data = service.GetAll();
            return Ok(data);
        }

        // GET: api/Patient/get/{id}
        [HttpGet("get/{id}")]
        public IActionResult Get(int id)
        {
            var data = service.Get(id);
            if (data == null) 
                return NotFound();
            return Ok(data);
        }

        // POST: api/Patient/create
        [HttpPost("create")]
        public IActionResult Create(PatientDTO dto)
        {
            var result = service.Create(dto);
            if (!result) 
                return BadRequest("Failed.");
            return Ok("Patient data created");
        }

        // PUT: api/Patient/update
        [HttpPut("update")]
        public IActionResult Update(PatientDTO dto)
        {
            var result = service.Update(dto);
            if (!result) 
                return BadRequest("Update failed.");
            return Ok("Patient updated");
        }

        // DELETE: api/Patient/delete/{id}
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var result = service.Delete(id);
            if (!result) 
                return NotFound("Patient not found");
            return Ok("Patient data deleted");
        }

        // GET: api/Patient/by-email
        [HttpGet("by-email")]
        public IActionResult GetByEmail(string email)
        {
            var data = service.GetByEmail(email);
            if (data == null) 
                return NotFound();
            return Ok(data);
        }

        // GET: api/Patient/by-gender/{gender}
        [HttpGet("by-gender/{gender}")]
        public IActionResult GetByGender(string gender)
        {
            var data = service.GetByGender(gender);
            return Ok(data);
        }

        // GET: api/Patient/ByPatient/{patientId}
        [HttpGet("ByPatient/{patientId}")]
        public ActionResult<List<PatientDiagnosisDTO>> GetPatientReport(int patientId)
        {
            var data = s.GetPatientDiagnosisById(patientId);
            if (data == null || data.Count == 0)
                return NotFound("No data found for this patient.");

            return Ok(data);
        }
    }
}
