using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.TestEquipmentDetail.Validators
{
    public class UpdateTestEquipmentDetailDtoValidator : AbstractValidator<TestEquipmentDetailDto>
    {
        public UpdateTestEquipmentDetailDtoValidator()
        {
            Include(new ITestEquipmentDetailDtoValidator());

            RuleFor(p => p.TestEquipmentDetailId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
