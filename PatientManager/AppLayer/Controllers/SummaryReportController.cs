using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppLayer.Controllers
{
    [Route("api/summary")]
    [ApiController]
    public class SummaryReportController : ControllerBase
    {
        ReportService service;

        public SummaryReportController(ReportService service)
        {
            this.service = service;
        }

        // api/summary/sum
        [HttpGet("sum")]
        public IActionResult SystemSummary()
        {
            return Ok(service.GetSystemSummary());
        }

        // api/summary/status-sum
        [HttpGet("status-sum")]
        public IActionResult AppointmentStatus()
        {
            return Ok(service.GetAppointmentStatusSummary());
        }
    }
}
