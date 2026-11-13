using MarketManagement.DTOs.Categories;
using MarketManagement.Entities;
using MarketManagement.Repositories.Interfaces;
using MarketManagement.Services.Interfaces;

namespace MarketManagement.Services.Implementations;

public class CategoryService : ICategoryService
{
    private readonly IGenericRepository<Category> _repository;

    public CategoryService(IGenericRepository<Category> repository)
    {
        _repository = repository;
    }

    public async Task<List<Category>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Category?> GetByIdAsync(Guid id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task AddAsync(CreateCategoryDto dto)
    {
        var category = new Category
        {
            Name = dto.Name,
        };  

        await _repository.AddAsync(category);
        await _repository.SaveChangesAsync();
    }

    public async Task<bool> UpdateAsync(Guid id, UpdateCategoryDto dto)
    {
        var category = await _repository.GetByIdAsync(id);

        if (category == null)
            return false;

        category.Name = dto.Name;

        _repository.Update(category);
        await _repository.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var category = await _repository.GetByIdAsync(id);

        if (category == null)
            return false;

        _repository.Delete(category);
        await _repository.SaveChangesAsync();

        return true;
    }
}