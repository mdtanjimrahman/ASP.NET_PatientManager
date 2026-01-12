using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        AppointmentService service;

        public AppointmentController(AppointmentService service)
        {
            this.service = service;
        }

        // GET: api/appointment/all
        [HttpGet("all")]
        public ActionResult<List<AppointmentDTO>> GetAll()
        {
            return Ok(service.GetAll());
        }

        // GET: api/appointment/get/1
        [HttpGet("get/{id}")]
        public ActionResult<AppointmentDTO> Get(int id)
        {
            var data = service.GetById(id);
            if (data == null) 
                return NotFound();
            return Ok(data);
        }

        // POST: api/appointment/create
        [HttpPost("create")]
        public ActionResult Create(AppointmentDTO dto)
        {
            if (service.Create(dto))
                return Ok("Appointment created");

            return BadRequest("failed");
        }

        // PUT: api/appointment/update
        [HttpPut("update")]
        public ActionResult Update(AppointmentDTO dto)
        {
            if (service.Update(dto))
                return Ok("Appointment updated");

            return BadRequest("failed");
        }

        // DELETE: api/appointment/delete/5
        [HttpDelete("delete/{id}")]
        public ActionResult Delete(int id)
        {
            if (service.Delete(id))
                return Ok("appointment deleted");

            return NotFound();
        }


        //Feature

        // PUT: api/appointment/change-status/{appointmentId}/{status}  status: Scheduled, Completed, Canceled
        [HttpPut("ChngStat/{appointmentId}/{status}")]
        public ActionResult ChangeStatus(int appointmentId, string status)
        {
            if (service.ChangeStatus(appointmentId, status))
                return Ok("Status updated");

            return BadRequest("failed");
        }

        // GET: api/appointment/doctor/{doctorId}
        [HttpGet("doctor/{doctorId}")]
        public ActionResult<List<AppointmentDTO>> GetByDoctor(int doctorId)
        {
            return Ok(service.GetByDoctor(doctorId));
        }

        // GET: api/appointment/patient/{patientId}
        [HttpGet("patient/{patientId}")]
        public ActionResult<List<AppointmentDTO>> GetByPatient(int patientId)
        {
            return Ok(service.GetByPatient(patientId));
        }
    }
}
