using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace EliteABP.Develop.Authors;
public interface IAuthorTestAppService : IApplicationService
{
    Task CreateAsync(CreateAuthorDto input);
    Task<AuthorDto> GetAsync(Guid id);
    Task<PagedResultDto<AuthorDto>> GetAllAsync(PagedAndSortedResultRequestDto input);
}