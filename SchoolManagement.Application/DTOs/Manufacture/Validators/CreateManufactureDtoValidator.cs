using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Manufacture.Validators
{
    public class CreateManufactureDtoValidator : AbstractValidator<CreateManufactureDto>
    {
        public CreateManufactureDtoValidator()  
        {
            Include(new IManufactureDtoValidator()); 
        }
    }
}
