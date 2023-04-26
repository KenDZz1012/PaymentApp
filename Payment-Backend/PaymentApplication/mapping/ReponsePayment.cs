using MediatR;
using PaymentDomain.VN_Pay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApplication.mapping
{
    public class ReponsePayment : PaymentDomain.VN_Pay.ReponseVNPayTransaction, IRequest<ReponseTransaction>
    {
    }
}
