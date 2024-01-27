using FluentValidation;

namespace SchoolManagement.Application.DTOs.CstTec.Validators 
{
    public class CreateCstTecDtoValidator : AbstractValidator<CreateCstTecDto>
    {
        public CreateCstTecDtoValidator()
        {
            Include(new ICstTecDtoValidator());
        }
    }
}
 