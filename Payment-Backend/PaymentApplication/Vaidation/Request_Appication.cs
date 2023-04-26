using FluentValidation;
using MediatR;
using PaymentDomain.VN_Pay;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApplication.Request
{
    public class Request_Appication 
    {
        public class Payment : AbstractValidator<PaymentApplication.mapping.Payment> 
        {
            public Payment() 
            {
                RuleFor(x => x.IpAddress).Null().WithMessage("IP: Required");
                RuleFor(x => x.OrderInfo).Null().WithMessage("OrderInfo: Required");
                RuleFor(x => x.OrderType).Null().WithMessage("OrderType: Required");
                RuleFor(x => x.Amount).Null().WithMessage("Amount: Required");
            }
        }
        

    }
}
