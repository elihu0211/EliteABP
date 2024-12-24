namespace EliteABP.Develop.Authors.Entities;
public class Author : AggregateRoot<Guid> /*聚合根*/
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    protected Author() { } //提供給 ORM 框架用
    public Author(Guid id, string name, string description)
    {
        Id = id;
        Name = Check.NotNullOrWhiteSpace(name, nameof(name));
        Description = description;
    }
}