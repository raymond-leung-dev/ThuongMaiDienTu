using System.ComponentModel.DataAnnotations;

namespace DoGiaDung.Domain.Entities;

/// <summary>
/// Bảng từ điển đa ngôn ngữ. Hỗ trợ ES (default), EN, VI.
/// </summary>
public class SysDictionary
{
    [Key]
    public int DicId { get; set; }

    /// <summary>Loại ngôn ngữ: 'ES', 'EN', 'VI'</summary>
    [Required, MaxLength(10)]
    public string LngTp { get; set; } = "ES";

    /// <summary>Mã từ khóa: 'NAV_HOME', 'BTN_ADD_TO_CART', 'MSG_LOGIN_ERR'...</summary>
    [Required, MaxLength(100)]
    public string ColCd { get; set; } = string.Empty;

    /// <summary>Mã phụ trong nhóm, mặc định '0'</summary>
    [MaxLength(50)]
    public string ColCdTp { get; set; } = "0";

    public int SortSeq { get; set; } = 1;

    /// <summary>Văn bản hiển thị (đã dịch)</summary>
    [Required, MaxLength(500)]
    public string ColCdTpNm { get; set; } = string.Empty;

    // --- Audit columns ---
    [MaxLength(14)] public string? RegDt { get; set; }
    [MaxLength(14)] public string? ClsDt { get; set; }
    [MaxLength(50)] public string? WorkMn { get; set; }
    [MaxLength(14)] public string? WorkDt { get; set; }
    [MaxLength(50)] public string? WorkIp { get; set; }
    [MaxLength(50)] public string? CnfmSeq { get; set; }
    [MaxLength(50)] public string? CnfmUser { get; set; }
    [MaxLength(14)] public string? CnfmDt { get; set; }
    [MaxLength(50)] public string? CnfmIp { get; set; }
    [MaxLength(10)] public string? VsdTp { get; set; }
    [MaxLength(500)] public string? Note { get; set; }
}
