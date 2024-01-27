using MediatR;
using SchoolManagement.Application.DTOs.MaintenancePlanning;

namespace SchoolManagement.Application.Features.MaintenancePlannings.Requests.Queries
{
    public class GetMaintenancePlanningDetailRequest : IRequest<MaintenancePlanningDto>
    {
        public int MaintenancePlanningId { get; set; }
    }
}
