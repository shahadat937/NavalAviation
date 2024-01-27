using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.RunningHour.Validators
{
    public class UpdateRunningHourDtoValidator : AbstractValidator<RunningHourDto>
    {
        public UpdateRunningHourDtoValidator()
        {
            Include(new IRunningHourDtoValidator());

            //RuleFor(b => b.RunningHourId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

