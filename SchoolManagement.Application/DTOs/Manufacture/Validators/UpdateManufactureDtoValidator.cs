using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.Manufacture.Validators
{
    public class UpdateManufactureDtoValidator : AbstractValidator<ManufactureDto>
    {
        public UpdateManufactureDtoValidator()
        {
            Include(new IManufactureDtoValidator());

            RuleFor(b => b.ManufactureId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

