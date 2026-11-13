using MarketManagement.DTOs.Stores;
using MarketManagement.Entities;
using MarketManagement.Repositories.Interfaces;
using MarketManagement.Services.Interfaces;

namespace MarketManagement.Services.Implementations;

public class StoreService : IStoreService
{
    private readonly IGenericRepository<Store> _repository;
    private readonly IGenericRepository<User> _userRepository;

    public StoreService(
        IGenericRepository<Store> repository,
        IGenericRepository<User> userRepository)
    {
        _repository = repository;
        _userRepository = userRepository;
    }

    public async Task<List<Store>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Store?> GetByIdAsync(Guid id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task AddAsync(CreateStoreDto dto)
    {
        var seller = await _userRepository.GetByIdAsync(dto.SellerId);

        if (seller == null || seller.Role != UserRole.Seller)
            throw new ArgumentException("Seller not found.");

        var store = new Store
        {
            Name = dto.Name,
            SellerId = dto.SellerId
        };

        await _repository.AddAsync(store);
        await _repository.SaveChangesAsync();
    }

    public async Task<bool> UpdateAsync(Guid id, UpdateStoreDto dto)
    {
        var store = await _repository.GetByIdAsync(id);

        if (store == null)
            return false;

        store.Name = dto.Name;

        _repository.Update(store);
        await _repository.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var store = await _repository.GetByIdAsync(id);

        if (store == null)
            return false;

        _repository.Delete(store);
        await _repository.SaveChangesAsync();

        return true;
    }
}