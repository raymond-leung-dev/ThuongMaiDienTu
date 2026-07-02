using DoGiaDung.Application.Interfaces;
using Microsoft.AspNetCore.Html;

namespace DoGiaDung.Web.Helpers;

/// <summary>
/// Injected into all Views via _ViewImports: @inject Lang Lang
/// Usage: @Lang.Get("NAV_HOME")
/// </summary>
public class Lang
{
    private readonly IDictionaryService _dict;

    public Lang(IDictionaryService dict) => _dict = dict;

    /// <summary>Lấy text đã dịch</summary>
    public HtmlString Get(string colCd, string colCdTp = "0")
        => new(_dict.Get(colCd, colCdTp));

    /// <summary>Lấy raw string (dùng cho attribute, placeholder...)</summary>
    public string GetRaw(string colCd, string colCdTp = "0")
        => _dict.Get(colCd, colCdTp);
}
