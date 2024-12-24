using FluentValidation;
using Volo.Abp.Application.Dtos;

namespace EliteABP.Develop.Authors;
public class CreateAuthorDto : EntityDto
{
    public required string Name { get; init; }
    public required string Description { get; init; }

    public class Validator : AbstractValidator<CreateAuthorDto>
    {
        public Validator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required.");
        }
    }
}