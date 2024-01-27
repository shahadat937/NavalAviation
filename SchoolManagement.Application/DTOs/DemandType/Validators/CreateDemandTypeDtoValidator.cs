using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.DemandType.Validators
{
    public class CreateDemandTypeDtoValidator : AbstractValidator<CreateDemandTypeDto>
    {
        public CreateDemandTypeDtoValidator()  
        {
            Include(new IDemandTypeDtoValidator()); 
        }
    }
}
