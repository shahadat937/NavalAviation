using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.TestEquipmentDetail.Validators
{
    public class CreateTestEquipmentDetailDtoValidator : AbstractValidator<CreateTestEquipmentDetailDto>
    {
        public CreateTestEquipmentDetailDtoValidator()
        {
            Include(new ITestEquipmentDetailDtoValidator());
        }
    }
}
