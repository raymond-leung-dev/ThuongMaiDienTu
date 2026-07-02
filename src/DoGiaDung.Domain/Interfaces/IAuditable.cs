namespace DoGiaDung.Domain.Interfaces;

/// <summary>
/// Áp dụng cho entity cần audit trail (theo dõi ai tạo/sửa, lúc nào).
/// </summary>
public interface IAuditable
{
    string? CreatedBy { get; set; }
    DateTime CreatedDt { get; set; }
    string? UpdatedBy { get; set; }
    DateTime? UpdatedDt { get; set; }
}
