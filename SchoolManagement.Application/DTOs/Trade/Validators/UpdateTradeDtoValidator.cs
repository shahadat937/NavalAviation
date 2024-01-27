using FluentValidation;

namespace SchoolManagement.Application.DTOs.Trade.Validators
{
    public class UpdateTradeDtoValidator : AbstractValidator<TradeDto>
    {
        public UpdateTradeDtoValidator()
        {
            Include(new ITradeDtoValidator());

            RuleFor(b => b.TradeId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

