namespace DoGiaDung.Domain.Enums;

public enum TransactionStatus
{
    Cancelled = -1,    // Đã hủy
    Pending = 0,       // Chờ xử lý
    Processing = 1,    // Đang xử lý
    Confirmed = 2,     // Đã xác nhận
    Paid = 3           // Đã thanh toán
}
