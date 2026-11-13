namespace MarketManagement.Entities;

public sealed class Product : AuditableEntity
{
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public Guid CategoryId { get; set; }
    public Guid StoreId { get; set; }

    public Category Category { get; set; }
    public Store Store { get; set; }
   
}
