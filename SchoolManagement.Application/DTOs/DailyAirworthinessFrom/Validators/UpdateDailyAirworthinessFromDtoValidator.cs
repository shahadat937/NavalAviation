using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.DailyAirworthinessFrom.Validators
{
    public class UpdateDailyAirworthinessFromDtoValidator : AbstractValidator<CreateDailyAirworthinessFromDto>
    {
        public UpdateDailyAirworthinessFromDtoValidator()
        {
            Include(new IDailyAirworthinessFromDtoValidator());

            RuleFor(b => b.DailyAirworthinessFromId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

