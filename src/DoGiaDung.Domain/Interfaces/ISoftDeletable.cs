namespace DoGiaDung.Domain.Interfaces;

/// <summary>
/// Áp dụng cho tất cả entity hỗ trợ soft delete.
/// Entity có interface này sẽ tự động bị filter với Global Query Filter trong EF Core.
/// </summary>
public interface ISoftDeletable
{
    string DelYn { get; set; } // 'N' = active, 'Y' = deleted
}
