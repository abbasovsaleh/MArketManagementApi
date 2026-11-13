using MarketManagement.DTOs.Orders;
using MarketManagement.Entities;

namespace MarketManagement.Services.Interfaces;

public interface IOrderService
{
    Task<List<Order>> GetAllAsync();
    Task<Order?> GetByIdAsync(Guid id);
    Task AddAsync(CreateOrderDto dto);
    Task<bool> DeleteAsync(Guid id);
}