using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.StockTransferNsd.Validators
{
    public class CreateStockTransferNsdDtoValidator : AbstractValidator<CreateStockTransferNsdDto>
    {
        public CreateStockTransferNsdDtoValidator()  
        {
            Include(new IStockTransferNsdDtoValidator()); 
        }
    }
}
