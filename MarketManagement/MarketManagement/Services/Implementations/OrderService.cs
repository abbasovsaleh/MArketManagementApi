using MarketManagement.DTOs.Orders;
using MarketManagement.Entities;
using MarketManagement.Repositories.Interfaces;
using MarketManagement.Services.Interfaces;

namespace MarketManagement.Services.Implementations;

public class OrderService : IOrderService
{
    private readonly IGenericRepository<Order> _repository;
    private readonly IGenericRepository<Product> _productRepository;
    private readonly IGenericRepository<User> _userRepository;

    public OrderService(
        IGenericRepository<Order> repository,
        IGenericRepository<Product> productRepository,
        IGenericRepository<User> userRepository)
    {
        _repository = repository;
        _productRepository = productRepository;
        _userRepository = userRepository;
    }

    public async Task<List<Order>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Order?> GetByIdAsync(Guid id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task AddAsync(CreateOrderDto dto)
    {
        var buyer = await _userRepository.GetByIdAsync(dto.BuyerId);

        if (buyer == null || buyer.Role != UserRole.Buyer)
            throw new ArgumentException("Buyer not found.");

        if (dto.Products.Count == 0)
            throw new ArgumentException("Order must contain products.");

        var order = new Order
        {
            BuyerId = dto.BuyerId,
            TotalPrice = 0
        };

        foreach (var item in dto.Products)
        {
            var product = await _productRepository.GetByIdAsync(item.ProductId);

            if (product == null)
                throw new ArgumentException("Product not found.");

            if (item.Quantity <= 0 || product.StockQuantity < item.Quantity)
                throw new ArgumentException("Invalid product quantity.");

            var subtotal = product.Price * item.Quantity;

            order.Products.Add(new OrderItem
            {
                ProductId = product.Id,
                Quantity = item.Quantity,
                SubTotal = subtotal
            });

            order.TotalPrice += subtotal;

            product.StockQuantity -= item.Quantity;
            _productRepository.Update(product);
        }

        await _repository.AddAsync(order);
        await _repository.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var order = await _repository.GetByIdAsync(id);

        if (order == null)
            return false;

        _repository.Delete(order);
        await _repository.SaveChangesAsync();

        return true;
    }
}