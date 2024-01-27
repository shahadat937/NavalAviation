using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.TestEquipmentDetail.Validators
{
    public class ITestEquipmentDetailDtoValidator : AbstractValidator<ITestEquipmentDetailDto>
    {
        public ITestEquipmentDetailDtoValidator()
        {
            RuleFor(p => p.EquipmentName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

            
        }
    }
}
