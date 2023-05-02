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
        /// <summary>
        /// Create URL payment services
        /// </summary>
        /// <param name="Request">Đối số mặc định truyền vào</param>
        /// <returns></returns>
        [HttpPost("Payment")]
        public async Task<IActionResult> CreatePayment(PaymentApplication.mapping.Payment Request)
        {
            return Created("Payment", await _Mediator.Send(Request));
        }
        /// <summary>
        /// Chuyển đổi dữ liệu của VN pay lưu xuống DB payment services -> Trả về Front end các thông tin cần thiết
        /// </summary>
        /// <param name="Request"></param>
        /// <returns></returns>
        [HttpGet("Payment")]
        public async Task<IActionResult> GetPayment([FromQuery] PaymentApplication.mapping.ReponsePayment Request)
        {
            var data = await _Mediator.Send(Request);
            string Header = PaymentInfratructure.Pay.VN_Pay.VNPAY_CS_ASPX.Utils.ConvertClassToParamert<PaymentDomain.VN_Pay.ReponseTransaction>(data);
            string baseUrl = string.Format("http://localhost:3000/PaymentStatus{0}", Header);
            return Redirect(baseUrl);
        }

        /// <summary>
        /// Lấy trạng thái bên VN pay và Payment services
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpGet("Payment/Transaction")]
        public async Task<IActionResult> GetStatusPayment([FromQuery]string ID)
        {
            return Ok(ID);
        }
    }
}
