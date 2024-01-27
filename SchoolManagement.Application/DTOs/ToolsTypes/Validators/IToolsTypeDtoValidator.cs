
using FluentValidation;

namespace SchoolManagement.Application.DTOs.ToolsTypes.Validators
{
    public class IToolsTypeDtoValidator : AbstractValidator<IToolsTypeDto>
    {
        public IToolsTypeDtoValidator()
        {
            RuleFor(b => b.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
