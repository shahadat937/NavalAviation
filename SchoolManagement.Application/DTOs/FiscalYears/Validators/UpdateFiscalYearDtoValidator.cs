using FluentValidation;

namespace SchoolManagement.Application.DTOs.FiscalYears.Validators
{
    public class UpdateFiscalYearDtoValidator : AbstractValidator<FiscalYearDto>
    {
        public UpdateFiscalYearDtoValidator() 
        {
            Include(new IFiscalYearDtoValidator());

            RuleFor(b => b.FiscalYearId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
