namespace DoGiaDung.Application.DTOs;

public record ProductDto(
    int ProductId,
    string ProductName,
    decimal Price,
    decimal PriceWithVat,
    decimal VatRate,
    string? ImageLink,
    string? Description,
    int? Quantity,
    int? CatalogId,
    string? CatalogName,
    int? TagId,
    string? TagName
);

public record ProductSearchDto(
    string? Name,
    int? CatalogId,
    int? TagId,
    decimal? MinPrice,
    decimal? MaxPrice,
    int Page = 1,
    int PageSize = 20
);

public record ProductCreateDto(
    string ProductName,
    decimal Price,
    string? Description,
    int? Quantity,
    int? CatalogId,
    int? TagId,
    decimal VatRate = 0.21m
);
