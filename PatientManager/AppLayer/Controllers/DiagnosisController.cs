using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiagnosisController : ControllerBase
    {
        DiagnosisService service;

        public DiagnosisController(DiagnosisService service)
        {
            this.service = service;
        }

        // GET: api/diagnosis/all
        [HttpGet("all")]
        public ActionResult<List<DiagnosisDTO>> GetAll()
        {
            return Ok(service.GetAll());
        }

        // GET: api/diagnosis/get/{id}
        [HttpGet("get/{id}")]
        public ActionResult<DiagnosisDTO> Get(int id)
        {
            var data = service.GetById(id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        // POST: api/diagnosis/create
        [HttpPost("create")]
        public ActionResult Create(DiagnosisDTO dto)
        {
            if (service.Create(dto))
                return Ok("Diagnosis report created");

            return BadRequest("failed");
        }

        // PUT: api/diagnosis/update
        [HttpPut("update")]
        public ActionResult Update(DiagnosisDTO dto)
        {
            if (service.Update(dto))
            {
                return Ok("Diagnosis report updated");
            }
            return BadRequest("failed");
        }

        // DELETE: api/diagnosis/delete/{id}
        [HttpDelete("delete/{id}")]
        public ActionResult Delete(int id)
        {
            if (service.Delete(id))
                return Ok("Diagnosis report deleted");

            return NotFound();
        }


        //Features

        // GET: api/diagnosis/patient/{patientId}
        [HttpGet("patient/{patientId}")]
        public ActionResult<List<DiagnosisDTO>> GetByPatient(int patientId)
        {
            return Ok(service.GetByPatient(patientId));
        }

        // GET: api/diagnosis/doctor/{doctorId}
        [HttpGet("doctor/{doctorId}")]
        public ActionResult<List<DiagnosisDTO>> GetByDoctor(int doctorId)
        {
            return Ok(service.GetByDoctor(doctorId));
        }

        // GET: api/diagnosis/recent/{days}
        [HttpGet("recent/{days}")]
        public ActionResult<List<DiagnosisDTO>> GetRecentDiagnoses(int days)
        {
            return Ok(service.GetRecentDiagnoses(days));
        }
    }
}
