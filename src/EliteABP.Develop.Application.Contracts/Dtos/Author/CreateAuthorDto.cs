using Volo.Abp.Application.Dtos;

namespace EliteABP.Develop.Dtos.Author;
public class CreateAuthorDto : EntityDto
{
    public string Name { get; set; }
    public string Description { get; set; }
}