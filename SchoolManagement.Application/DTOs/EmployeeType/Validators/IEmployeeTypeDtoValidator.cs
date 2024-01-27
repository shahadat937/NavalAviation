
using FluentValidation;
using SchoolManagement.Application.DTOs.EmployeeType;

namespace SchoolManagement.Application.DTOs.EmployeeType.Validators
{
    public class IEmployeeTypeDtoValidator : AbstractValidator<IEmployeeTypeDto>
    {
        public IEmployeeTypeDtoValidator()
        {
            RuleFor(b => b.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
