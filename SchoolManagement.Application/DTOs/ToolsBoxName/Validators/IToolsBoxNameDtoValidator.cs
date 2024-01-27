
using FluentValidation;

namespace SchoolManagement.Application.DTOs.ToolsBoxNames.Validators
{
    public class IToolsBoxNameDtoValidator : AbstractValidator<IToolsBoxNameDto>
    {
        public IToolsBoxNameDtoValidator()
        {
            RuleFor(b => b.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
 