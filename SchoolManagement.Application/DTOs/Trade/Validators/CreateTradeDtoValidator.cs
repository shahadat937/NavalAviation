using FluentValidation;

namespace SchoolManagement.Application.DTOs.Trade.Validators
{
    public class CreateTradeDtoValidator : AbstractValidator<CreateTradeDto>
    {
        public CreateTradeDtoValidator()  
        {
            Include(new ITradeDtoValidator()); 
        }
    }
}
