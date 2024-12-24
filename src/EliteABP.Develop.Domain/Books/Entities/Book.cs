namespace EliteABP.Develop.Books.Entities;
public class Book : AuditedAggregateRoot<Guid>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public IEnumerable<Volume> Volumes { get; protected set; }
}