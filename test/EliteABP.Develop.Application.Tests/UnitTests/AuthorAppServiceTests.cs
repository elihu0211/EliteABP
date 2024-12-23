using EliteABP.Develop.Dtos.Author;
using Shouldly;
using Volo.Abp.Application.Dtos;

namespace EliteABP.Develop.Application.Tests.UnitTests;

public class AuthorAppServiceTests : DevelopApplicationTestBase
{
    readonly IAuthorAppService _authorAppService;
    public AuthorAppServiceTests()
    {
        _authorAppService = GetRequiredService<IAuthorAppService>();
    }

    [Fact]
    public async Task Should_Create_A_Valid_Author()
    {
        await WithUnitOfWorkAsync(async () =>
        {
            await Should.NotThrowAsync(async () =>
            {
                var input = new CreateAuthorDto
                {
                    Name = "張家老三",
                    Description = "中國內地不知名網路小說作家",
                };
                await _authorAppService.CreatrAsync(input);
            });
        });
    }

    [Fact]
    public async Task Should_Get_PagedAndSorted_Of_Authors()
    {
        var result = await WithUnitOfWorkAsync(async () =>
        {
            var input = new PagedAndSortedResultRequestDto
            {
                SkipCount = 0,
                MaxResultCount = 10,
                Sorting = "Name"
            };

            return await _authorAppService.GetListAsync(input);
        });

        result.TotalCount.ShouldBe(1);
        result.Items.Count.ShouldBe(1);
    }
}