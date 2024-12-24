namespace EliteABP.Develop.Categories.Entities;
public class Category : AuditedAggregateRoot<Guid>
{
    public string Name { get; set; } = null!;
}