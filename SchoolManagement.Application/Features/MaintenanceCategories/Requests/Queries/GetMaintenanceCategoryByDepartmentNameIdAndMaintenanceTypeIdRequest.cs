using MediatR;
using SchoolManagement.Application.DTOs.MaintenanceCategory;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text; 

namespace SchoolManagement.Application.Features.MaintenanceCategories.Requests.Queries
{
    public class GetMaintenanceCategoryByDepartmentNameIdAndMaintenanceTypeIdRequest : IRequest<List<SelectedModel>>
    {
        public int DepartmentNameId { get; set; }  
        public int MaintenanceTypeId { get; set; }
    }
} 
