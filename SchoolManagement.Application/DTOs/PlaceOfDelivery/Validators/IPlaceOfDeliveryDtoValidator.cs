using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.PlaceOfDelivery.Validators
{
    public class IPlaceOfDeliveryDtoValidator : AbstractValidator<IPlaceOfDeliveryDto>
    {
        public IPlaceOfDeliveryDtoValidator() 
        {
            RuleFor(b => b.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
