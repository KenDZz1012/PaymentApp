using PaymentDomain.VN_Pay;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentInfratructure.Pay.VN_Pay
{
    public class VNpayPaymentServices
    {
        public static VNpayPaymentServices instance = new();

        private ReponseVNPayTransaction ReponseVNPayTransaction;
        public VNpayPaymentServices VNpayReturnTransaction(ReponseVNPayTransaction reponsePayment)
        {
            ReponseVNPayTransaction = reponsePayment;
            return this;
        }
        public async Task<ReponseTransaction> ReponseTransaction()
        {
            ReponseTransaction reponse = new ReponseTransaction();
            reponse.Messenger = ConvertPayMessenger(ReponseVNPayTransaction.vnp_TransactionStatus);
            reponse.PayStatus = ReponseVNPayTransaction.vnp_TransactionStatus == 0;
            reponse.vnp_TxnRef = ReponseVNPayTransaction.vnp_TxnRef;
            reponse.vnp_TransactionStatus = ReponseVNPayTransaction.vnp_TransactionStatus;
            reponse.vnp_TransactionNo = ReponseVNPayTransaction.vnp_TransactionNo;
            return reponse;
        }
        private string ConvertPayMessenger(int vnp_TransactionStatus)
        {
            switch (vnp_TransactionStatus)
            {
                case 0: return "Thanh toán thành công";
                default:  return "Có lỗi xảy ra khi thanh toán";
                   
            }
        }
      
    }
}
