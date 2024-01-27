using MediatR;
using SchoolManagement.Application.DTOs.MaintenanceType;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text; 

namespace SchoolManagement.Application.Features.MaintenanceTypes.Requests.Queries
{
    public class GetMaintenanceTypeByDepartmentNameIdRequest : IRequest<List<SelectedModel>>
    {
        public int DepartmentNameId { get; set; }    
    }
} 
