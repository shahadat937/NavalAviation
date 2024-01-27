using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.PartOfShipment.Validators
{
    public class UpdatePartOfShipmentDtoValidator : AbstractValidator<PartOfShipmentDto>
    {
        public UpdatePartOfShipmentDtoValidator()
        {
            Include(new IPartOfShipmentDtoValidator());

            RuleFor(b => b.PartOfShipmentId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

