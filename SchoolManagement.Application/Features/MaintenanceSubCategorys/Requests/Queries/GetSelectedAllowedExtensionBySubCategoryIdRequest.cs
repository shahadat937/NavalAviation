using MediatR;
using SchoolManagement.Application.DTOs.CodeValues;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text; 

namespace SchoolManagement.Application.Features.MaintenanceSubCategorys.Requests.Queries
{
    public class GetSelectedAllowedExtensionBySubCategoryIdRequest : IRequest<List<SelectedModel>>
    {
        public int MaintenanceSubCategoryId { get; set; }    
    }
} 

