using Volo.Abp.Application.Dtos;

namespace EliteABP.Develop.Authors;
public class AuthorDto : EntityDto<Guid>
{
    public required string Name { get; init; }
    public required string Description { get; init; }
}