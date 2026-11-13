using MarketManagement.DTOs.Products;
using MarketManagement.Entities;

namespace MarketManagement.Services.Interfaces;

public interface IProductService
{
    Task<Product?> GetByIdAsync(Guid id);
    Task<List<Product>> GetAllAsync();
    Task AddAsync(CreateProductDto product);
    Task<bool> UpdateAsync(Guid id, UpdateProductDto product);
    Task<bool> DeleteAsync(Guid id);
}