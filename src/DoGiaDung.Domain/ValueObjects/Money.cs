namespace DoGiaDung.Domain.ValueObjects;

/// <summary>
/// Value object cho tiền tệ. Mặc định EUR (€) — thị trường Tây Ban Nha.
/// </summary>
public record Money(decimal Amount, string Currency = "EUR")
{
    public static Money Eur(decimal amount) => new(amount, "EUR");

    public static Money operator +(Money a, Money b)
    {
        if (a.Currency != b.Currency)
            throw new InvalidOperationException($"Cannot add different currencies: {a.Currency} and {b.Currency}");
        return new Money(a.Amount + b.Amount, a.Currency);
    }

    public static Money operator *(Money a, int quantity) => new(a.Amount * quantity, a.Currency);

    public override string ToString() => Currency switch
    {
        "EUR" => $"{Amount:N2} €",
        "USD" => $"${Amount:N2}",
        _ => $"{Amount:N2} {Currency}"
    };
}
