using EliteABP.Develop.Books.Entities;

namespace EliteABP.Develop.Books;
public interface IBookRepository : IRepository<Book, Guid>
{
    // 尋找章節編號
    Task<Chapter> FindChapterByIdAsync(Guid id, bool include = true, CancellationToken cancellationToken = default);
}