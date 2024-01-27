using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.DailyAirworthinessFromCategory.Validators
{
    public class UpdateDailyAirworthinessFromCategoryDtoValidator : AbstractValidator<DailyAirworthinessFromCategoryDto>
    {
        public UpdateDailyAirworthinessFromCategoryDtoValidator()
        {
            Include(new IDailyAirworthinessFromCategoryDtoValidator());

            RuleFor(b => b.DailyAirworthinessFromCategoryId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

