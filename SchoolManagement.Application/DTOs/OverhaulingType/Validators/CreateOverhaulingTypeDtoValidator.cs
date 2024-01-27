using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.OverhaulingType.Validators
{
    public class CreateOverhaulingTypeDtoValidator : AbstractValidator<CreateOverhaulingTypeDto>
    {
        public CreateOverhaulingTypeDtoValidator()  
        {
            Include(new IOverhaulingTypeDtoValidator()); 
        }
    }
}
