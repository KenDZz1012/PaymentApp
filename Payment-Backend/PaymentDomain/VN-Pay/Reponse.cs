using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentDomain.VN_Pay
{
    public class Reponse
    {
        public string URL_PaymentServices { get; set; }
        public DateTime CreateURL { get; set; }
        public string vnp_TxnRef { get; set; }
    }
    public class ReponseVNPayTransaction : Main
    {
        public int vnp_TransactionStatus { get; set; }
        public int vnp_TransactionNo { get; set; }
        public string vnp_PayDate { get; set; }
        public string vnp_CardType { get; set; }
    }
    public class ReponseTransaction : ReponseVNPayTransaction
    {
        public string Code { get; set; }
        public string Router { get; set; }
        public string status { get; set; }
        public  string Messenger { get; set; }

    }
}
