using Microsoft.Extensions.Configuration;
using PaymentInfratructure.DataProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PaymentDomain.VN_Pay.Request;

namespace PaymentApplication.ConfigEnv
{
    public class Config_VNPay
    {
        private readonly PaymentDomain.VN_Pay.Request.RequestToVNPay_CreateUrlPayment GetENV_requestToVNPay_CreateUrlPayment = new RequestToVNPay_CreateUrlPayment();
        public Config_VNPay()
        {
        
        }
        public RequestToVNPay_CreateUrlPayment CreateConnection()
            => GetENV_requestToVNPay_CreateUrlPayment;

    }
}
