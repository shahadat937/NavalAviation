using FluentValidation;

namespace SchoolManagement.Application.DTOs.CstTec.Validators 
{
    public class UpdateCstTecDtoValidator : AbstractValidator<CstTecDto>
    {
        public UpdateCstTecDtoValidator() 
        {
            Include(new ICstTecDtoValidator());

            RuleFor(b => b.CstTecId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
