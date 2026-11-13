using MarketManagement.DTOs.Categories;
using MarketManagement.Entities;

namespace MarketManagement.Services.Interfaces;

public interface ICategoryService
{
    Task<List<Category>> GetAllAsync();
    Task<Category?> GetByIdAsync(Guid id);
    Task AddAsync(CreateCategoryDto dto);
    Task<bool> UpdateAsync(Guid id, UpdateCategoryDto dto);
    Task<bool> DeleteAsync(Guid id);
}