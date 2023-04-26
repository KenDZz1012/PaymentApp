using PaymentDomain.VN_Pay;
using PaymentInfratructure.Pay.VN_Pay.VNPAY_CS_ASPX;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static PaymentDomain.VN_Pay.Request;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PaymentInfratructure.Pay.VN_Pay
{
    public class VNPayServices : IDisposable
    {
        public static VNPayServices instance = new();
        private Request.RequestAPI _RequestAPI;
        private string _UrlBase;
        private Request.RequestToVNPay_CreateUrlPayment _RequestToVNPay_CreateUrlPayment;


        public VNPayServices Url_Par(string Urlbase)
        {
            _UrlBase = Urlbase;
            return this;
        }
        public VNPayServices Request_Par(Request.RequestAPI RequestAPI)
        {
            _RequestAPI = RequestAPI;
            return this;
        }
        public VNPayServices RequestToVNPay_Par(Request.RequestToVNPay_CreateUrlPayment RequestToVNPay_CreateUrlPayment)
        {
            _RequestToVNPay_CreateUrlPayment = RequestToVNPay_CreateUrlPayment;
            return this;
        }
        public async Task<string> CreatePaymentAsync()
        {
            string Result = string.Empty;

            _RequestToVNPay_CreateUrlPayment.vnp_Amount = _RequestAPI.Amount;
            _RequestToVNPay_CreateUrlPayment.vnp_CreateDate = DateTime.Now.ToString("yyyyMMddHHmmss");
            _RequestToVNPay_CreateUrlPayment.vnp_IpAddr = _RequestAPI.IpAddress;
            _RequestToVNPay_CreateUrlPayment.vnp_OrderInfo = _RequestAPI.OrderInfo;
            _RequestToVNPay_CreateUrlPayment.vnp_OrderType = _RequestAPI.OrderType;

            VnPayLibrary vnpay = new VnPayLibrary();
            vnpay.AddRequestData("vnp_Version", VnPayLibrary.VERSION);
            vnpay.AddRequestData("vnp_Command", "pay");
            vnpay.AddRequestData("vnp_TmnCode", _RequestToVNPay_CreateUrlPayment.vnp_TmnCode);
            vnpay.AddRequestData("vnp_Amount", (_RequestToVNPay_CreateUrlPayment.vnp_Amount * 100).ToString());
            vnpay.AddRequestData("vnp_CreateDate", _RequestToVNPay_CreateUrlPayment.vnp_CreateDate);
            vnpay.AddRequestData("vnp_CurrCode", "VND");
            vnpay.AddRequestData("vnp_IpAddr", _RequestToVNPay_CreateUrlPayment.vnp_IpAddr);
            vnpay.AddRequestData("vnp_Locale", "vn");
            vnpay.AddRequestData("vnp_OrderInfo", "Thanh toan don hang:" + _RequestToVNPay_CreateUrlPayment.vnp_OrderInfo);
            vnpay.AddRequestData("vnp_OrderType", _RequestToVNPay_CreateUrlPayment.vnp_OrderType);
            vnpay.AddRequestData("vnp_ReturnUrl", _RequestToVNPay_CreateUrlPayment.vnp_ReturnUrl);
            vnpay.AddRequestData("vnp_TxnRef", _RequestToVNPay_CreateUrlPayment.vnp_TxnRef);

            string paymentUrl = vnpay.CreateRequestUrl(_UrlBase, "YETBDLQFUPTHWXAXPDBXCDMBLOTVHZSS");
            Dispose();
            return paymentUrl;

        }
        public void Dispose()
        {
            _RequestAPI = null;
        }
    }
}
