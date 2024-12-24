using EliteABP.Develop.Books;
using EliteABP.Develop.Books.Entities;
using Volo.Abp.Threading;

namespace EliteABP.Develop.Repositories.Extensions;
public static class BookRepositoryExtensions
{
    public static Chapter FindChapterById(this IBookRepository bookRepository, Guid id, bool include = true)
    {
        return AsyncHelper.RunSync(() =>
        {
            return bookRepository.FindChapterByIdAsync(id, include);
        });
    }
}