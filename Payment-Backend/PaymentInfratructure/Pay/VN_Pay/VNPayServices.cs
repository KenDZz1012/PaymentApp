using PaymentDomain.VN_Pay;
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
            Result =  ConvertClassToParamert<RequestToVNPay_CreateUrlPayment>(_RequestToVNPay_CreateUrlPayment);
            _RequestToVNPay_CreateUrlPayment.vnp_SecureHash = HmacSHA512("YETBDLQFUPTHWXAXPDBXCDMBLOTVHZSS", Result);
            Result = _UrlBase + "?" + Result + $"&vnp_SecureHash={_RequestToVNPay_CreateUrlPayment.vnp_SecureHash}";
            Dispose();
            return Result;
        }
        private string ConvertClassToParamert<T>(T objectClass) where T : class
        {
            string Result = string.Empty;
            Type myObjectType = objectClass.GetType();
            var indexer = new object[0];
            PropertyInfo[] properties = myObjectType.GetProperties();
            foreach (var info in properties)
            {
                var value = info.GetValue(objectClass, indexer);
                if (value != null)
                {
                    Result += WebUtility.UrlEncode(info.Name) + "=" + WebUtility.UrlEncode(value?.ToString() ?? "") + "&";
                }
             
            }
            if (Result.Length > 0)
            {
                Result = Result.Remove(Result.Length - 1, 1);
            }
            return Result;
        }
        private string HmacSHA512(string key, System.String inputData)
        {
            var hash = new StringBuilder();
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] inputBytes = Encoding.UTF8.GetBytes(inputData);
            using (var hmac = new HMACSHA512(keyBytes))
            {
                byte[] hashValue = hmac.ComputeHash(inputBytes);
                foreach (var theByte in hashValue)
                {
                    hash.Append(theByte.ToString("x2"));
                }
            }

            return hash.ToString();
        }


        public void Dispose()
        {
            _RequestAPI = null;
        }


    }
}
