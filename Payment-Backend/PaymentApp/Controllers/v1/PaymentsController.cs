using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentApplication.interfaces;
using static PaymentApplication.Request.Request_Appication;

namespace Payment_Services.Controllers.v1
{
    [Route("v1/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        public IMediator _Mediator { get; set; }
        public PaymentsController(IMediator Mediator)
        {
            _Mediator = Mediator; 
        }

        [HttpPost("Payment")]
        public async Task<IActionResult> CreatePayment(PaymentApplication.mapping.Payment Request)
        {
            return Ok(await _Mediator.Send(Request));
        }
    }
}
