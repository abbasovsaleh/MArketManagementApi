namespace MarketManagement.Entities;

public class BaseEntity
{
    public Guid Id { get; init; }
}

public abstract class AuditableEntity : BaseEntity
{
    public DateTime CreatedAt { get; set; }
    public Guid? CreatedBy { get; set; }
}