namespace MarketManagement.DTOs.Stores;

public class CreateStoreDto
{
    public string Name { get; set; } = null!;
    public Guid SellerId { get; set; }
}