using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.PartOfShipment.Validators
{
    public class CreatePartOfShipmentDtoValidator : AbstractValidator<CreatePartOfShipmentDto>
    {
        public CreatePartOfShipmentDtoValidator()  
        {
            Include(new IPartOfShipmentDtoValidator()); 
        }
    }
}
