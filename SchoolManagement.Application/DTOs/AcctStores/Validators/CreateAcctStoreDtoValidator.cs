using FluentValidation;

namespace SchoolManagement.Application.DTOs.AcctStores.Validators
{
    public class CreateAcctStoreDtoValidator : AbstractValidator<CreateAcctStoreDto>
    {
        public CreateAcctStoreDtoValidator()
        {
            Include(new IAcctStoreDtoValidator());
        }
    }
}
 