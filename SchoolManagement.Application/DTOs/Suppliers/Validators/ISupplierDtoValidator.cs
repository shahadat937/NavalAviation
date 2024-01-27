
using FluentValidation;

namespace SchoolManagement.Application.DTOs.Suppliers.Validators
{
    public class ISupplierDtoValidator : AbstractValidator<ISupplierDto>
    {
        public ISupplierDtoValidator()
        {
            RuleFor(b => b.CompanyName)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
