using FluentValidation;

namespace SchoolManagement.Application.DTOs.AcctStores.Validators
{
    public class UpdateAcctStoreDtoValidator : AbstractValidator<AcctStoreDto>
    {
        public UpdateAcctStoreDtoValidator() 
        {
            Include(new IAcctStoreDtoValidator());

            RuleFor(b => b.AcctStoreId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
