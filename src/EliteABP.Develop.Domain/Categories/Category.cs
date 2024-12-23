namespace EliteABP.Develop.Categories;
public class Category : AuditedAggregateRoot<Guid>
{/* 帶有審計屬性的聚合根(審計屬性: 創建者ID、創建時間、更新者ID、更新時間) */
    public string Name { get; set; } = null!;
    protected Category() { } //提供給 ORM 框架用
    public Category(Guid id, string name)
    {
        Id = id;
        Name = Check.NotNullOrWhiteSpace(name, nameof(name));
    }
}