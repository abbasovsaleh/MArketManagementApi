namespace MarketManagement.DTOs.Orders;

public class CreateOrderDto
{
    public Guid BuyerId { get; set; }
    public List<CreateOrderItemDto> Products { get; set; } = new();
}