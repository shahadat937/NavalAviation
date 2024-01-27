using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.DailyAirworthinessFromCategory.Validators
{
    public class CreateDailyAirworthinessFromCategoryDtoValidator : AbstractValidator<CreateDailyAirworthinessFromCategoryDto>
    {
        public CreateDailyAirworthinessFromCategoryDtoValidator()  
        {
            Include(new IDailyAirworthinessFromCategoryDtoValidator()); 
        }
    }
}
