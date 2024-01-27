using MediatR;
using SchoolManagement.Application.DTOs.RequiredSparesForMaintenance;

namespace SchoolManagement.Application.Features.RequiredSparesForMaintenances.Requests.Queries
{
    public class GetRequiredSparesForMaintenanceListByDepartmentNameIdRequest : IRequest<List<RequiredSparesForMaintenanceDto>>
    {
        
        public int DepartmentNameId { get; set; }
    } 
}

