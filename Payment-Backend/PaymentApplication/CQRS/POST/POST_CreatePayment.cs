using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaymentApplication.Request;
using PaymentDomain.VN_Pay;
using PaymentApplication.interfaces;
using static PaymentApplication.Request.Request_Appication;
using Microsoft.Extensions.Logging;
using static PaymentDomain.VN_Pay.Request;

namespace PaymentApplication.CQRS.POST
{
    public class POST_CreatePayment : IRequestHandler<mapping.Payment, Reponse>
    {
        private ILogger<POST_CreatePayment> _logger { get; set; }
        private IConnection_Payment _payment { get; set; }
        public POST_CreatePayment(IConnection_Payment payment, ILogger<POST_CreatePayment> logger)
        {
            _payment = payment ?? throw new ArgumentNullException(nameof(payment)  + "is null");
            _logger = logger ?? throw new ArgumentNullException(nameof(_logger) + "is null");
        }
        public async Task<Reponse> Handle(mapping.Payment request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(POST_CreatePayment), request); 
            return await _payment.PostPayment(request, cancellationToken);
        }
    }
}
