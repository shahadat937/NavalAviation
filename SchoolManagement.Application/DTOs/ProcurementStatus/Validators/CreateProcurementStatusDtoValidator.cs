using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.ProcurementStatus.Validators
{
    public class CreateProcurementStatusDtoValidator : AbstractValidator<CreateProcurementStatusDto>
    {
        public CreateProcurementStatusDtoValidator()  
        {
            Include(new IProcurementStatusDtoValidator()); 
        }
    }
}
