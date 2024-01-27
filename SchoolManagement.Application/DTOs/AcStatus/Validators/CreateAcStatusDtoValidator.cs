using FluentValidation;

namespace SchoolManagement.Application.DTOs.AcStatus.Validators 
{
    public class CreateAcStatusDtoValidator : AbstractValidator<CreateAcStatusDto>
    {
        public CreateAcStatusDtoValidator()
        {
            Include(new IAcStatusDtoValidator());
        }
    }
}
 