using MediatR;
using SchoolManagement.Shared.Models;
using System; 
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.MaintenanceSchedules.Requests.Queries
{
    public class GetSelectedMaintenancePlanningByParametersFromSubCategoryRequest : IRequest<int>
    {
        public int MaintenanceCategoryId { get; set; }
       // public int MaintenancePlanningId { get; set; }  
        public int DepartmentNameId { get; set; }
    }
}

 