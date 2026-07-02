namespace DoGiaDung.Application.Interfaces;

/// <summary>
/// Service tra cứu nội dung đa ngôn ngữ.
/// Ngôn ngữ mặc định: ES (Español).
/// </summary>
public interface IDictionaryService
{
    /// <summary>Lấy text theo mã, ngôn ngữ hiện tại. Fallback: ES → EN → mã gốc</summary>
    string Get(string colCd, string colCdTp = "0");

    /// <summary>Lấy cả nhóm text, vd tất cả NAV_* keys</summary>
    Dictionary<string, string> GetGroup(string prefix);

    /// <summary>Ngôn ngữ hiện tại của user</summary>
    string CurrentLanguage { get; }

    /// <summary>Chuyển đổi ngôn ngữ</summary>
    void SetLanguage(string lang);
}
