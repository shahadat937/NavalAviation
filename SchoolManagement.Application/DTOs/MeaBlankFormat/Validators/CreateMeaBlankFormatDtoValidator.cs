using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.MeaBlankFormat.Validators
{
    public class CreateMeaBlankFormatDtoValidator : AbstractValidator<CreateMeaBlankFormatDto>
    {
        public CreateMeaBlankFormatDtoValidator()  
        {
            Include(new IMeaBlankFormatDtoValidator()); 
        }
    }
}
