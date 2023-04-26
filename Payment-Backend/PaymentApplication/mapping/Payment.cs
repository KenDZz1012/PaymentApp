using MediatR;
using PaymentDomain.VN_Pay;

namespace PaymentApplication.mapping
{
    public class Payment : PaymentDomain.VN_Pay.Request.RequestAPI , IRequest<Reponse>
    {
      
    }
}
