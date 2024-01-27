using FluentValidation;
using SchoolManagement.Application.DTOs.SparesCategorys;

namespace SchoolManagement.Application.DTOs.SparesCategory.Validators
{
    public class CreateSparesCategoryDtoValidator : AbstractValidator<CreateSparesCategoryDto>
    {
        public CreateSparesCategoryDtoValidator()
        { 
            Include(new ISparesCategoryDtoValidator());
        }
    }
}
 