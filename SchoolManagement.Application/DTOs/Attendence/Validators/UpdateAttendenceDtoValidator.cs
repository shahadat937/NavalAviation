using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.Attendence.Validators
{
    public class UpdateAttendenceDtoValidator : AbstractValidator<AttendenceDto>
    {
        public UpdateAttendenceDtoValidator()
        {
            Include(new IAttendenceDtoValidator());

            RuleFor(b => b.AttendenceId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

