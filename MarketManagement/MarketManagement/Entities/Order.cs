namespace MarketManagement.Entities;

public sealed class Order : AuditableEntity
{
    public Guid BuyerId { get; set; }
    public List<OrderItem> Products { get; set; }
    public decimal TotalPrice { get; set; }

    public User Buyer { get; set; }
}