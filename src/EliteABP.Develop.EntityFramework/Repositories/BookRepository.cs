using EliteABP.Develop.Books;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace EliteABP.Develop.Repositories;
public class BookRepository(IDbContextProvider<DevelopDbContext> dbContextProvider) : EfCoreRepository<DevelopDbContext, Book, Guid>(dbContextProvider), IBookRepository
{
    public async Task<Chapter> FindChapterByIdAsync(Guid id, bool include = true, CancellationToken cancellationToken = default)
    {
        var chapters = (await GetDbContextAsync()).Chapters;
        var result = await chapters.IncludeIf(include, chapter => chapter.ChapterText)
            .FirstOrDefaultAsync(chapter => chapter.Id == id,
            GetCancellationToken(cancellationToken));

        return result;
    }
}