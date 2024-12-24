namespace EliteABP.Develop.Books.Entities;
public class Chapter : Entity<Guid>, IHasCreationTime /* 審計接口 */
{
    public Volume Volume { get; set; } // 導航屬性
    public Guid VolumeId { get; set; } // 外鍵

    public string Title { get; set; }
    public ChapterText ChapterText { get; protected set; } // 導航屬性
    public int WordNumber { get; set; }

    public DateTime CreationTime { get; }

    protected Chapter() { } // 提供給 ORM 框架用
    public Chapter(
        string title,
        string content,
        string authorMessage)
    {
        Title = Check.NotNullOrWhiteSpace(title, nameof(title));
        WordNumber = content.Length;

        ChapterText = new ChapterText(content, authorMessage);
    }
}
