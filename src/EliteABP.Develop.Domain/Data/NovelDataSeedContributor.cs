using EliteABP.Develop.Authors;
using EliteABP.Develop.Books;
using EliteABP.Develop.Categories;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Data;
using Volo.Abp.Guids;

namespace EliteABP.Develop.Data;

[Dependency(ServiceLifetime.Transient)]
public class NovelDataSeedContributor : IDataSeedContributor
{
    readonly IRepository<Author, Guid> _authorRepository;
    readonly IRepository<Category, Guid> _categoryRepository;
    readonly IRepository<Book, Guid> _bookRepository;
    readonly List<Guid> _guids = [];
    public NovelDataSeedContributor(
        IGuidGenerator guidGenerator,
        IRepository<Author, Guid> authorRepository,
        IRepository<Category, Guid> categoryRepository,
        IRepository<Book, Guid> bookRepository)
    {
        _authorRepository = authorRepository;
        _bookRepository = bookRepository;
        _categoryRepository = categoryRepository;

        for (int i = 0; i < 3; i++)
        {
            _guids.Add(guidGenerator.Create());
        }
    }

    // [數據播種]
    public async Task SeedAsync(DataSeedContext context)
    {
        await CreateAuthorAsync().ConfigureAwait(false);
        await CreateCategoryAsync().ConfigureAwait(false);
        await CreateBookAsync().ConfigureAwait(false);
    }
    async Task CreateAuthorAsync()
    {
        Author author = new(_guids[0], "劉慈欣", "著名科幻小說作者");

        await _authorRepository.InsertAsync(author).ConfigureAwait(false);
    }
    async Task CreateCategoryAsync()
    {
        Category category = new(_guids[1], "科幻");

        await _categoryRepository.InsertAsync(category).ConfigureAwait(false);
    }
    async Task CreateBookAsync()
    {
        Book book = new(
            _guids[2], "三體", "科幻小說史詩巨作",
            _guids[0], "劉慈欣",
            _guids[1], "科幻");

        book.AddVolume("三體1", "外星人");
        book.Volumes[0].AddChapter("第一章", "正文1", "作者的留言");
        await _bookRepository.InsertAsync(book).ConfigureAwait(false);
    }
}