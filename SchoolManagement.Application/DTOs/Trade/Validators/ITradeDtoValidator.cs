using FluentValidation;

namespace SchoolManagement.Application.DTOs.Trade.Validators
{
    public class ITradeDtoValidator : AbstractValidator<ITradeDto>
    {
        public ITradeDtoValidator() 
        {
            RuleFor(b => b.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
