using MediatR;

namespace SchoolManagement.Application.Features.MaintenancePlannings.Requests.Queries
{
    public class GetSpAcUnderMaintenanceRequest : IRequest<object>
    {
        public DateTime? Current { get; set; }
        public int DepartmentId { get; set; }
    }
}
