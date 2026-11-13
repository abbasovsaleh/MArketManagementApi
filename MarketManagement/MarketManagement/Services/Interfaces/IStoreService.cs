using MarketManagement.DTOs.Stores;
using MarketManagement.Entities;

namespace MarketManagement.Services.Interfaces;

public interface IStoreService
{
    Task<List<Store>> GetAllAsync();
    Task<Store?> GetByIdAsync(Guid id);
    Task AddAsync(CreateStoreDto dto);
    Task<bool> UpdateAsync(Guid id, UpdateStoreDto dto);
    Task<bool> DeleteAsync(Guid id);
}