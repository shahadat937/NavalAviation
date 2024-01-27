using MediatR;
using SchoolManagement.Application.DTOs.GseMaintenanceScheduleName;

namespace SchoolManagement.Application.Features.GseMaintenanceScheduleNames.Requests.Queries
{
    public class GetGseMaintenanceScheduleNameDetailRequest : IRequest<GseMaintenanceScheduleNameDto>
    {
        public int GseMaintenanceScheduleNameId { get; set; }
    }
}
