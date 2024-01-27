using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.PlaceOfDelivery.Validators
{
    public class UpdatePlaceOfDeliveryDtoValidator : AbstractValidator<PlaceOfDeliveryDto>
    {
        public UpdatePlaceOfDeliveryDtoValidator()
        {
            Include(new IPlaceOfDeliveryDtoValidator());

            RuleFor(b => b.PlaceOfDeliveryId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

