using EliteABP.Develop.Dtos.Author;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace EliteABP.Develop;
public interface IAuthorAppService : IApplicationService
{
    Task CreatrAsync(CreateAuthorDto input);
    Task<AuthorDto> GetAsync(Guid id);
    Task<PagedResultDto<AuthorDto>> GetListAsync(PagedAndSortedResultRequestDto input);
}