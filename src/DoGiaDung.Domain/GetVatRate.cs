namespace DoGiaDung.Domain;

/// <summary>
/// IVA Española — Thuế VAT Tây Ban Nha.
/// </summary>
public static class VatRates
{
    /// <summary>21% — General: áp dụng cho hầu hết sản phẩm</summary>
    public const decimal General = 0.21m;

    /// <summary>10% — Reducido: thực phẩm, vận chuyển, khách sạn</summary>
    public const decimal Reduced = 0.10m;

    /// <summary>4% — Superreducido: bánh mì, sữa, sách, thuốc</summary>
    public const decimal SuperReduced = 0.04m;

    /// <summary>
    /// Tính giá đã bao gồm VAT từ giá chưa thuế.
    /// </summary>
    public static decimal PriceWithVat(decimal priceWithoutVat, decimal vatRate = General)
        => priceWithoutVat * (1 + vatRate);

    /// <summary>
    /// Tính số tiền VAT từ giá đã bao gồm thuế.
    /// </summary>
    public static decimal VatAmount(decimal priceWithVat, decimal vatRate = General)
        => priceWithVat - (priceWithVat / (1 + vatRate));
}
