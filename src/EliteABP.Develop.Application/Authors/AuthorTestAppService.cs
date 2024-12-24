using AutoMapper;
using EliteABP.Develop.Authors.Entities;
using EliteABP.Develop.Localization;
using FluentValidation;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Localization;

namespace EliteABP.Develop.Authors;
public class AuthorTestAppService : ApplicationService, IAuthorTestAppService
{
    public async Task CreateAsync(CreateAuthorDto input)
    {

        var ll = LocalizableString.Create<DevelopResource>("LongWelcomeMessage");

       
        await CreateAuthorDtoValidator.ValidateAsync(input);

        var author = ObjectMapper.Map<CreateAuthorDto, Author>(input);
        await AuthorRepository.InsertAsync(author);
    }
    public async Task<AuthorDto> GetAsync(Guid id)
    {
        var author = await AuthorRepository.GetAsync(id);
        return ObjectMapper.Map<Author, AuthorDto>(author);
    }
    public async Task<PagedResultDto<AuthorDto>> GetAllAsync(PagedAndSortedResultRequestDto input)
    {
        var count = await AuthorRepository.GetCountAsync();

        var list = await AuthorRepository.GetPagedListAsync(
            input.SkipCount,
            input.MaxResultCount,
            input.Sorting ?? string.Empty);

        return new PagedResultDto<AuthorDto>
        {
            TotalCount = count,
            Items = ObjectMapper.Map<List<Author>, List<AuthorDto>>(list)
        };
    }
    public class AppProfile : Profile
    {
        public AppProfile()
        {
            CreateMap<CreateAuthorDto, Author>();
            CreateMap<Author, AuthorDto>();
        }
    }
    public required IAuthorRepository AuthorRepository { get; init; }
    public required IValidator<CreateAuthorDto> CreateAuthorDtoValidator { get; init; }
}