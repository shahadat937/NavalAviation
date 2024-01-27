using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.PlaceOfDelivery.Validators
{
    public class CreatePlaceOfDeliveryDtoValidator : AbstractValidator<CreatePlaceOfDeliveryDto>
    {
        public CreatePlaceOfDeliveryDtoValidator()  
        {
            Include(new IPlaceOfDeliveryDtoValidator()); 
        }
    }
}
