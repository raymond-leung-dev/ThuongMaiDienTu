using System.Collections.Concurrent;
using DoGiaDung.Application.Interfaces;
using DoGiaDung.Domain.Entities;
using DoGiaDung.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;

namespace DoGiaDung.Infrastructure.Services;

/// <summary>
/// Tra cứu nội dung đa ngôn ngữ với MemoryCache.
/// Fallback order: ES → EN → mã COL_CD gốc nếu không tìm thấy.
/// </summary>
public class CachedDictionaryService : IDictionaryService
{
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly IMemoryCache _cache;
    private static readonly ConcurrentDictionary<string, string> _localCache = new();
    private static readonly object _lock = new();
    private static DateTime _lastLoad = DateTime.MinValue;
    private static readonly TimeSpan CacheDuration = TimeSpan.FromMinutes(30);

    private static readonly AsyncLocal<string> _currentLang = new();

    public string CurrentLanguage => _currentLang.Value ?? "ES";

    public void SetLanguage(string lang) => _currentLang.Value = lang;

    public CachedDictionaryService(IServiceScopeFactory scopeFactory, IMemoryCache cache)
    {
        _scopeFactory = scopeFactory;
        _cache = cache;
    }

    public string Get(string colCd, string colCdTp = "0")
    {
        EnsureLoaded();
        var lang = CurrentLanguage;

        // Try current language
        var key = $"{lang}:{colCd}:{colCdTp}";
        if (_localCache.TryGetValue(key, out var val))
            return val!;

        // Fallback to ES
        if (lang != "ES")
        {
            var esKey = $"ES:{colCd}:{colCdTp}";
            if (_localCache.TryGetValue(esKey, out var esVal))
                return esVal!;
        }

        // Fallback to EN
        if (lang != "EN" && lang != "ES")
        {
            var enKey = $"EN:{colCd}:{colCdTp}";
            if (_localCache.TryGetValue(enKey, out var enVal))
                return enVal!;
        }

        // Last resort: return the code itself
        return colCd;
    }

    public Dictionary<string, string> GetGroup(string prefix)
    {
        EnsureLoaded();
        var lang = CurrentLanguage;
        return _localCache
            .Where(kv => kv.Key.StartsWith($"{lang}:{prefix}"))
            .ToDictionary(kv => kv.Key.Split(':')[1], kv => kv.Value);
    }

    private void EnsureLoaded()
    {
        if ((DateTime.UtcNow - _lastLoad) < CacheDuration)
            return;

        lock (_lock)
        {
            if ((DateTime.UtcNow - _lastLoad) < CacheDuration)
                return;

            ReloadFromDatabase();
            _lastLoad = DateTime.UtcNow;
        }
    }

    private void ReloadFromDatabase()
    {
        using var scope = _scopeFactory.CreateScope();
        using var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        var all = db.SysDictionaries.AsNoTracking().ToList();
        _localCache.Clear();
        foreach (var item in all)
        {
            var key = $"{item.LngTp}:{item.ColCd}:{item.ColCdTp}";
            _localCache[key] = item.ColCdTpNm;
        }
    }

    /// <summary>Force reload cache (gọi khi admin sửa từ điển)</summary>
    public static void InvalidateCache()
    {
        _lastLoad = DateTime.MinValue;
    }
}
