using FluentValidation;
using SchoolManagement.Application.DTOs.SparesCategorys;

namespace SchoolManagement.Application.DTOs.SparesCategory.Validators
{
    public class ISparesCategoryDtoValidator : AbstractValidator<ISparesCategoryDto>
    {
        public ISparesCategoryDtoValidator()
        { 
            RuleFor(b => b.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
