using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        PaymentService service;

        public PaymentController(PaymentService service)
        {
            this.service = service;
        }


        // POST: api/Payment/pay/4/1000
        [HttpPost("pay/{appointmentId}/{amount}")]
        public IActionResult Pay(int appointmentId, double amount)
        {
            if (service.MakePayment(appointmentId, amount))
                return Ok("Payment successful.");

            return BadRequest("Payment failed");
        }
    }
}
