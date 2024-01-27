using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SchoolManagement.Application.DTOs.District.Validators
{
    public class CreateDistrictDtoValidator : AbstractValidator<CreateDistrictDto>
    {
        public CreateDistrictDtoValidator()
        {
            Include(new IDistrictDtoValidator());
        }
    }
}
