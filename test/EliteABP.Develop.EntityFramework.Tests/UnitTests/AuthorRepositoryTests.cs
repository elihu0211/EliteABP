using EliteABP.Develop.Authors.Entities;
using Shouldly;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;

namespace EliteABP.Develop.EntityFramework.Tests.UnitTests;
public sealed class AuthorRepositoryTests : DevelopEntityFrameworkTestBase
{
    readonly IRepository<Author, Guid> _authorRepository;
    readonly IGuidGenerator _guidGenerator;
    public AuthorRepositoryTests()
    {
        _authorRepository = GetRequiredService<IRepository<Author, Guid>>();
        _guidGenerator = GetRequiredService<IGuidGenerator>();
    }

    [Fact]
    public async Task Should_Insert_A_Valid_Author()
    {
        var testAuthor = new Author(
            _guidGenerator.Create(),
            "張家老三",
            "中國內地不知名網路小說家");

        // 插入資料庫
        await WithUnitOfWorkAsync(async () =>
        {
            await _authorRepository.InsertAsync(testAuthor);
        });

        { //(查詢是可以不用工作單元)

            // 查詢是否有插入資料庫
            var result = await WithUnitOfWorkAsync(async () =>
            {
                return await _authorRepository.FirstOrDefaultAsync(author =>
                author.Id == testAuthor.Id);
            });

            //斷言: 返回是否為空
            result.ShouldNotBeNull();
        }
    }

    [Fact]
    public async Task Should_Get_List_of_Authors()
    {
        var result = await WithUnitOfWorkAsync(async () =>
        {
            return await _authorRepository.GetListAsync();
        });

        //斷言: 數量是否大於 0
        result.Count.ShouldBeGreaterThan(0);
    }
}