
using FluentValidation;
using SchoolManagement.Application.DTOs.CstTec;

namespace SchoolManagement.Application.DTOs.CstTec.Validators
{
    public class ICstTecDtoValidator : AbstractValidator<ICstTecDto>
    {
        public ICstTecDtoValidator()
        {
            RuleFor(b => b.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
