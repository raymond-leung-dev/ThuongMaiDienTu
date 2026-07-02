using DoGiaDung.Application.Common;
using DoGiaDung.Application.DTOs;
using DoGiaDung.Application.Interfaces;
using DoGiaDung.Domain.Entities;
using DoGiaDung.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DoGiaDung.Infrastructure.Services;

public class ProductService : IProductService
{
    private readonly IRepository<Product> _productRepo;

    public ProductService(IRepository<Product> productRepo) => _productRepo = productRepo;

    public async Task<Result<IReadOnlyList<ProductDto>>> GetAllAsync(string? searchName = null)
    {
        IQueryable<Product> query = _productRepo.Query()
            .Include(p => p.Catalog)
            .Include(p => p.Tag);

        if (!string.IsNullOrWhiteSpace(searchName))
            query = query.Where(p => p.ProductName.Contains(searchName));

        var products = await query.ToListAsync();
        var dtos = products.Select(MapToDto).ToList();
        return Result<IReadOnlyList<ProductDto>>.Success(dtos);
    }

    public async Task<Result<ProductDto>> GetByIdAsync(int id)
    {
        var product = await _productRepo.Query()
            .Include(p => p.Catalog)
            .Include(p => p.Tag)
            .FirstOrDefaultAsync(p => p.ProductId == id);

        if (product == null)
            return Result<ProductDto>.Failure("Producto no encontrado.");

        return Result<ProductDto>.Success(MapToDto(product));
    }

    public async Task<Result<ProductDto>> CreateAsync(ProductCreateDto dto)
    {
        var product = new Product
        {
            ProductName = dto.ProductName,
            Price = dto.Price,
            Description = dto.Description,
            Quantity = dto.Quantity,
            CatalogId = dto.CatalogId,
            TagId = dto.TagId,
            VatRate = dto.VatRate,
            DelYn = "N",
            CreatedDt = DateTime.UtcNow
        };

        await _productRepo.AddAsync(product);
        return await GetByIdAsync(product.ProductId);
    }

    public async Task<Result> UpdateAsync(int id, ProductCreateDto dto)
    {
        var product = await _productRepo.GetByIdAsync(id);
        if (product == null)
            return Result.Failure("Producto no encontrado.");

        product.ProductName = dto.ProductName;
        product.Price = dto.Price;
        product.Description = dto.Description;
        product.Quantity = dto.Quantity;
        product.CatalogId = dto.CatalogId;
        product.TagId = dto.TagId;
        product.VatRate = dto.VatRate;

        await _productRepo.UpdateAsync(product);
        return Result.Ok();
    }

    public async Task<Result> DeleteAsync(int id)
    {
        var product = await _productRepo.GetByIdAsync(id);
        if (product == null)
            return Result.Failure("Producto no encontrado.");

        product.DelYn = "Y";
        await _productRepo.UpdateAsync(product);
        return Result.Ok();
    }

    public async Task<Result<ProductDto>> GetBySlugAsync(string slug)
    {
        // Simple fallback: search by name approximation
        var products = await _productRepo.FindAsync(p => p.ProductName.Contains(slug));
        var product = products.FirstOrDefault();
        if (product == null)
            return Result<ProductDto>.Failure("Producto no encontrado.");

        return Result<ProductDto>.Success(MapToDto(product));
    }

    private static ProductDto MapToDto(Product p) => new(
        p.ProductId,
        p.ProductName,
        p.Price,
        p.PriceWithVat,
        p.VatRate,
        p.ImageLink,
        p.Description,
        p.Quantity,
        p.CatalogId,
        p.Catalog?.CatalogName,
        p.TagId,
        p.Tag?.TagName
    );
}
