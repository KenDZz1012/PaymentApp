using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentDomain.VN_Pay
{
    public class Main
    {
        public Guid TransactionID { get; set; }
        /// <summary>
        /// Mã website của merchant trên hệ thống của VNPAY. Ví dụ: 2QXUI4J4
        /// </summary>
        [Required] public string vnp_TmnCode { get; set; }
        /// <summary>
        /// Mã Ngân hàng thanh toán. Ví dụ: NCB
        /// </summary>
        public string vnp_BankCode { get; set; }
        /// <summary>
        /// Mã kiểm tra (checksum) để đảm bảo dữ liệu của giao dịch không bị thay đổi trong quá trình chuyển từ merchant sang VNPAY. Việc tạo ra mã này phụ thuộc vào cấu hình của merchant và phiên bản api sử dụng. Phiên bản hiện tại hỗ trợ SHA256, HMACSHA512.
        /// </summary>
        [Required] public string vnp_SecureHash { get; set; }

        /// <summary>
        /// Mã tham chiếu của giao dịch tại hệ thống của merchant. Mã này là duy nhất dùng để phân biệt các đơn hàng gửi sang VNPAY. Không được trùng lặp trong ngày. Ví dụ: 23554
        /// </summary>
        [Required] public string vnp_TxnRef { get; set; }
        /// <summary>
        /// Thông tin mô tả nội dung thanh toán (Tiếng Việt, không dấu). Ví dụ: **Nap tien cho thue bao 0123456789. So tien 100,000 VND**
        /// </summary>
        [Required] public string vnp_OrderInfo { get; set; }
        /// <summary>
        /// Số tiền thanh toán. Số tiền không mang các ký tự phân tách thập phân, phần nghìn, ký tự tiền tệ. Để gửi số tiền thanh toán là 10,000 VND (mười nghìn VNĐ) thì merchant cần nhân thêm 100 lần (khử phần thập phân), sau đó gửi sang VNPAY là: 1000000
        /// </summary>
        [Required] public double vnp_Amount { get; set; }
    }
}
