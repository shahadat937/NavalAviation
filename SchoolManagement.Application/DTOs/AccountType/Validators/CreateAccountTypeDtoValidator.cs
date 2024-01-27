using FluentValidation;

namespace SchoolManagement.Application.DTOs.AccountType.Validators
{
    public class CreateAccountTypeDtoValidator : AbstractValidator<CreateAccountTypeDto>
    {
        public CreateAccountTypeDtoValidator()  
        {
            Include(new IAccountTypeDtoValidator()); 
        }
    }
}
