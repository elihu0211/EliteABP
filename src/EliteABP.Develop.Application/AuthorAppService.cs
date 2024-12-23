using EliteABP.Develop.Authors;
using EliteABP.Develop.Dtos.Author;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace EliteABP.Develop;
public class AuthorAppService(IAuthorRepository authorRepository) : ApplicationService, IAuthorAppService
{
    public async Task CreatrAsync(CreateAuthorDto input)
    {
        //Author author = new(GuidGenerator.Create(), input.Name, input.Description);

        Author author = ObjectMapper.Map<CreateAuthorDto, Author>(input);
        await authorRepository.InsertAsync(author);
    }
    public async Task<AuthorDto> GetAsync(Guid id)
    {
        Author author = await authorRepository.GetAsync(id);
        return ObjectMapper.Map<Author, AuthorDto>(author);

        //return new AuthorDto { Id = author.Id, Name = author.Name, Description = author.Description };
    }
    public async Task<PagedResultDto<AuthorDto>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        var count = await authorRepository.GetCountAsync();
        var list = await authorRepository.GetPagedListAsync(
            input.SkipCount,
            input.MaxResultCount,
            input.Sorting);

        return new PagedResultDto<AuthorDto>
        {
            TotalCount = count,
            Items = ObjectMapper.Map<List<Author>, List<AuthorDto>>(list)
        };
    }
}