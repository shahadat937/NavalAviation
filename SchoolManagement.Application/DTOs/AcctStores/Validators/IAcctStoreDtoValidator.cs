
using FluentValidation;

namespace SchoolManagement.Application.DTOs.AcctStores.Validators
{
    public class IAcctStoreDtoValidator : AbstractValidator<IAcctStoreDto>
    { 
        public IAcctStoreDtoValidator()
        {
            RuleFor(b => b.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
