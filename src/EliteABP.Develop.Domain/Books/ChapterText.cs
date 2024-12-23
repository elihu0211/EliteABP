namespace EliteABP.Develop.Books;
public class ChapterText : AuditedEntity<Guid> /* 帶有審計屬性的實體 */
{

    public Guid ChapterId { get; set; }// 外鍵屬性
    public Chapter Chapter { get; set; } // 導航屬性

    public string Content { get; set; }
    public string AuthorMessage { get; set; }

    protected ChapterText() { } // 提供給 ORM 框架用
    public ChapterText(string content, string authorMessage)
    {
        Content = Check.NotNullOrWhiteSpace(content, nameof(content));
        AuthorMessage = authorMessage;
    }
}