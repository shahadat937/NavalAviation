using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.DailyAirworthinessFrom.Validators
{
    public class CreateDailyAirworthinessFromDtoValidator : AbstractValidator<CreateDailyAirworthinessFromDto>
    {
        public CreateDailyAirworthinessFromDtoValidator()  
        {
            Include(new IDailyAirworthinessFromDtoValidator()); 
        }
    }
}
