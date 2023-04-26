using PaymentApplication.Request;
using PaymentDomain.VN_Pay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApplication.interfaces
{
    public interface IConnection_Payment
    {
        Task<Reponse> PostPayment(mapping.Payment Payment, CancellationToken cancellationToken);
        Task<ReponseTransaction> GetPayment(mapping.ReponsePayment Payment, CancellationToken cancellationToken);
    }
}
