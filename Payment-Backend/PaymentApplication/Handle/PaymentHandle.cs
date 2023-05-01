
using PaymentApplication.interfaces;
using PaymentApplication.mapping;
using PaymentApplication.Request;
using PaymentDomain.VN_Pay;
using PaymentInfratructure.Pay.VN_Pay;
using static PaymentDomain.VN_Pay.Request;

namespace PaymentApplication.Handle
{
    public class PaymentHandle : IConnection_Payment
    {
        public ConfigEnv.Config_VNPay _Config_VNPay { get; set; }
        public PaymentHandle(ConfigEnv.Config_VNPay Config_VNPay)
        {
            _Config_VNPay = Config_VNPay;
        }
        public async Task<Reponse> PostPayment(mapping.Payment Payment, CancellationToken cancellationToken)
        {
           string RexTef =Guid.NewGuid().ToString();
            Reponse reponse = new Reponse();
            reponse.URL_PaymentServices = await VNPayServices.instance
                .Request_Par(Payment)
                .RequestToVNPay_Par(new PaymentDomain.VN_Pay.Request.RequestToVNPay_CreateUrlPayment
                {
                    vnp_Version = "2.1.0",
                    vnp_Command = "pay",
                    vnp_TmnCode = "3FOBOVZ9",
                    vnp_TxnRef = RexTef
                })
                .Url_Par("https://sandbox.vnpayment.vn/paymentv2/vpcpay.html")
                .CreatePaymentAsync();
            reponse.CreateURL = DateTime.Now;
            reponse.vnp_TxnRef = RexTef;
            return reponse;
        }

        public async Task<ReponseTransaction> GetPayment(ReponsePayment Payment, CancellationToken cancellationToken)
        {
            return await PaymentInfratructure.Pay.VN_Pay.VNpayPaymentServices.instance.VNpayReturnTransaction(Payment).ReponseTransaction();
        }
    }
}
