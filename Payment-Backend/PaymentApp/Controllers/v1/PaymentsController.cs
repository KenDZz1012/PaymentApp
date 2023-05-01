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
            return Created("Payment", await _Mediator.Send(Request));
        }
        [HttpGet("Payment")]
        public async Task<IActionResult> GetPayment([FromQuery]PaymentApplication.mapping.ReponsePayment Request)
        {
            var data =  await _Mediator.Send(Request);
            string Header = PaymentInfratructure.Pay.VN_Pay.VNPAY_CS_ASPX.Utils.ConvertClassToParamert<PaymentDomain.VN_Pay.ReponseTransaction>(data);
            string baseUrl = string.Format("http://localhost:3000/PaymentStatus{0}", Header);
            return Redirect(baseUrl);
        }
    }
}
