using EliteABP.Develop.Authors.Entities;
using EliteABP.Develop.Books.Entities;
using EliteABP.Develop.Categories.Entities;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Data;
using Volo.Abp.Guids;

namespace EliteABP.Develop.Authors.Data;

[Dependency(ServiceLifetime.Transient)]
public class AuthorDataSeedContributor : IDataSeedContributor
{
    readonly IRepository<Author, Guid> _authorRepository;
    readonly IRepository<Category, Guid> _categoryRepository;
    readonly IRepository<Book, Guid> _bookRepository;
    readonly List<Guid> _guids = [];
    public AuthorDataSeedContributor(
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
    public Task SeedAsync(DataSeedContext context)
    {
        return Task.CompletedTask;
    }
}