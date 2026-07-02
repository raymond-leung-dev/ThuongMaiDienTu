using DoGiaDung.Application.Common;
using DoGiaDung.Application.DTOs;

namespace DoGiaDung.Application.Interfaces;

public interface IProductService
{
    Task<Result<IReadOnlyList<ProductDto>>> GetAllAsync(string? searchName = null);
    Task<Result<ProductDto>> GetByIdAsync(int id);
    Task<Result<ProductDto>> CreateAsync(ProductCreateDto dto);
    Task<Result> UpdateAsync(int id, ProductCreateDto dto);
    Task<Result> DeleteAsync(int id);
    Task<Result<ProductDto>> GetBySlugAsync(string slug);
}
