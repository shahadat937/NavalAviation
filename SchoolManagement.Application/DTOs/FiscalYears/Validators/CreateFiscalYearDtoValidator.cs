using FluentValidation;

namespace SchoolManagement.Application.DTOs.FiscalYears.Validators
{
    public class CreateFiscalYearDtoValidator : AbstractValidator<CreateFiscalYearDto>
    {
        public CreateFiscalYearDtoValidator()
        {
            Include(new IFiscalYearDtoValidator());
        }
    }
}
 