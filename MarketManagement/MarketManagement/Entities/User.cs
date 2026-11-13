namespace MarketManagement.Entities;

public sealed class User : AuditableEntity
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public ICollection<Store> Stores { get; set; } = new List<Store>();
    public UserRole Role { get; set; } = UserRole.Buyer;
}

public enum UserRole : byte
{
    Buyer = 1,
    Seller = 2,
    Admin = 3
}