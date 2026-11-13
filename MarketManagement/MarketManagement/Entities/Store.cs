namespace MarketManagement.Entities;

public sealed class Store : AuditableEntity
{
    public string Name { get; set; } = null!;
    public Guid SellerId { get; set; }
    public User Seller { get; set; }
    
    public ICollection<Store> Stores { get; set; } = new List<Store>();
    public ICollection<Product> Products { get; set; } = new List<Product>();
}