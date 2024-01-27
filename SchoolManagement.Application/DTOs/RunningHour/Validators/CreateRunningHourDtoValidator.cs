using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.RunningHour.Validators
{
    public class CreateRunningHourDtoValidator : AbstractValidator<CreateRunningHourDto>
    {
        public CreateRunningHourDtoValidator()  
        {
            Include(new IRunningHourDtoValidator()); 
        }
    }
}
