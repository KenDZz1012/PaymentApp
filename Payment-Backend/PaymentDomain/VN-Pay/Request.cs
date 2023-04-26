using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentDomain.VN_Pay
{
    public class Request
    {
        /// <summary>
        ///  Tạo URL Thanh toán
        /// URL Thanh toán là địa chỉ URL mang thông tin thanh toán.
        /// Website TMĐT gửi sang Cổng thanh toán VNPAY các thông tin này khi xử lý giao dịch thanh toán trực tuyến cho Khách mua hàng.
        /// https://sandbox.vnpayment.vn/paymentv2/vpcpay.html?vnp_Amount=1806000&vnp_Command=pay&vnp_CreateDate=20210801153333&vnp_CurrCode=VND&vnp_IpAddr=127.0.0.1&vnp_Locale=vn&vnp_OrderInfo=Thanh+toan+don+hang+%3A5&vnp_OrderType=other&vnp_ReturnUrl=https%3A%2F%2Fdomainmerchant.vn%2FReturnUrl&vnp_TmnCode=DEMOV210&vnp_TxnRef=5&vnp_Version=2.1.0&vnp_SecureHash=3e0d61a0c0534b2e36680b3f7277743e8784cc4e1d68fa7d276e79c23be7d6318d338b477910a27992f5057bb1582bd44bd82ae8009ffaf6d141219218625c42
        ///https://sandbox.vnpayment.vn/paymentv2/vpcpay.html?vnp_Version=2.1.0&vnp_Command=pay&vnp_TmnCode=3FOBOVZ9&vnp_Amount=100000&vnp_BankCode=VCB&vnp_CreateDate=20230425111719&vnp_CurrCode=VND&vnp_IpAddr=192.168.61.197&vnp_Locale=vn&vnp_OrderInfo=test&vnp_OrderType=test&vnp_ExpireDate=20230425111719&vnp_ReturnUrl=http%3A%2F%2Fcreasoft.top%2Freturn&vnp_TxnRef=38289f8a-28a2-46fe-bcab-40c47d697498&vnp_SecureHash=f08aeee07faa63000de81ea6f25480f24193238205f24eca77d3b904e29636e37a36bad8f463df987b19fff37f82f548af454f930522c12ac30bf7f8836e3ce9
        /// </summary>
        public class RequestToVNPay_CreateUrlPayment : Main
        {
            /// <summary>
            /// Phiên bản api mà merchant kết nối. Phiên bản hiện tại là : 2.0.1 và 2.1.0
            /// </summary>
            [Required] public string vnp_Version { get; set; }
            /// <summary>
            /// Mã API sử dụng, mã cho giao dịch thanh toán là: pay
            /// </summary>
            [Required] public string vnp_Command { get; set; }

            /// <summary>
            /// Là thời gian phát sinh giao dịch định dạng yyyyMMddHHmmss(Time zone GMT+7)Ví dụ: 20170829103111
            /// </summary>
            [Required] public string vnp_CreateDate { get; set; } = DateTime.Now.ToString("yyyyMMddHHmmss");
            /// <summary>
            /// Đơn vị tiền tệ sử dụng thanh toán. Hiện tại chỉ hỗ trợ VND
            /// </summary>
            [Required] public string vnp_CurrCode { get; set; } = "VND";
            /// <summary>
            /// Địa chỉ IP của khách hàng thực hiện giao dịch. Ví dụ: 13.160.92.202
            /// </summary>
            [Required] public string vnp_IpAddr { get; set; }
            /// <summary>
            /// Ngôn ngữ giao diện hiển thị. Hiện tại hỗ trợ Tiếng Việt (vn), Tiếng Anh (en)
            /// </summary>

            [Required] public string vnp_Locale { get; set; } = "vn";
        
            /// <summary>
            /// Mã danh mục hàng hóa. Mỗi hàng hóa sẽ thuộc một nhóm danh mục do VNPAY quy định. Xem thêm bảng Danh mục hàng hóa
            /// </summary>
            public string vnp_OrderType { get; set; }

            /// <summary>
            /// 	URL thông báo kết quả giao dịch khi Khách hàng kết thúc thanh toán. Ví dụ: https://domain.vn/VnPayReturn
            /// </summary>
            [Required] public string vnp_ReturnUrl { get; set; } = "https://localhost:7018/v1/Payments/Payment";
         
          

        }
        public class RequestAPI
        {
            public double Amount { get; set; }
            public string IpAddress { get; set; }
            public string OrderInfo { get; set; }
            public string OrderType { get; set; }
        }

    }
}
