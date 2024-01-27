using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Attendence.Validators
{
    public class CreateAttendenceDtoValidator : AbstractValidator<CreateAttendenceDto>
    {
        public CreateAttendenceDtoValidator()  
        {
            Include(new IAttendenceDtoValidator()); 
        }
    }
}
