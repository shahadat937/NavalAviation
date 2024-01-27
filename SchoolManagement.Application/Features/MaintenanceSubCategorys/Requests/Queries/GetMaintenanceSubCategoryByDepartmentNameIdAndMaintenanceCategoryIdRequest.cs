using MediatR;
using SchoolManagement.Application.DTOs.MaintenanceSubCategory;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text; 

namespace SchoolManagement.Application.Features.MaintenanceSubCategorys.Requests.Queries
{
    public class GetMaintenanceSubCategoryByDepartmentNameIdAndMaintenanceCategoryIdRequest : IRequest<List<SelectedModel>>
    {
        //public int DepartmentNameId { get; set; }  
        public int MaintenanceCategoryId { get; set; }
    }
} 
