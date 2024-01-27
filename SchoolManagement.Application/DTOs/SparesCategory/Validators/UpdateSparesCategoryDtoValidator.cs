using FluentValidation;
using SchoolManagement.Application.DTOs.SparesCategorys;

namespace SchoolManagement.Application.DTOs.SparesCategory.Validators
{
    public class UpdateSparesCategoryDtoValidator : AbstractValidator<SparesCategoryDto>
    {
        public UpdateSparesCategoryDtoValidator() 
        {
            Include(new ISparesCategoryDtoValidator());

            RuleFor(b => b.SparesCategoryId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
