using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.AirCraftName.Validators
{
    public class CreateAirCraftNameDtoValidator : AbstractValidator<CreateAirCraftNameDto>
    {
        public CreateAirCraftNameDtoValidator()  
        {
            Include(new IAirCraftNameDtoValidator()); 
        }
    }
}
