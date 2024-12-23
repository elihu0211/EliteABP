namespace EliteABP.Develop.Books;
public class Volume : Entity<Guid>, IHasCreationTime /* 審計接口: 創建時間 */
{
    public Book Book { get; set; }
    public Guid BookId { get; set; }

    public string Title { get; set; }
    public string Description { get; set; }

    public List<Chapter> Chapters { get; protected set; }

    public DateTime CreationTime { get; }

    protected Volume() { } // 提供給 ORM 框架用
    public Volume(string title, string description)
    {
        Title = title;
        Description = description;
        Chapters = [];
    }

    // 添加章節
    public void AddChapter(string title, string content, string authorMessage)
    {
        //防止添加標題相同的章節
        if (Chapters.Exists(volume => string.Equals(volume.Title, title, StringComparison.Ordinal))) return;

        Chapters.Add(new Chapter(title, content, authorMessage));
    }

    // 刪除指定章節
    public void RemoveChapter(Guid chapterId)
    {
        Chapters.RemoveAll(chapter => chapter.Id == chapterId);
    }
}