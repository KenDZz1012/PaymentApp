using MediatR;
using Microsoft.Extensions.Logging;
using PaymentApplication.CQRS.POST;
using PaymentApplication.interfaces;
using PaymentApplication.mapping;
using PaymentDomain.VN_Pay;


namespace PaymentApplication.CQRS.Get
{
    internal class Get_ReturnPaymentServices : IRequestHandler<mapping.ReponsePayment, ReponseTransaction>
    {
        private ILogger<POST_CreatePayment> _logger { get; set; }
        private IConnection_Payment _payment { get; set; }
        public Get_ReturnPaymentServices(ILogger<POST_CreatePayment> logger, IConnection_Payment payment)
        {
            _logger = logger;
            _payment = payment;
        }

        public async Task<ReponseTransaction> Handle(ReponsePayment request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("start request", request);
            return await _payment.GetPayment(request, cancellationToken);
        }
    }
}
