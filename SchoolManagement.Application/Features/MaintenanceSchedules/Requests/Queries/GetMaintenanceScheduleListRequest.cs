using MediatR;
using SchoolManagement.Application.DTOs.MaintenanceSchedule;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.MaintenanceSchedules.Requests.Queries
{
    public class GetMaintenanceScheduleListRequest : IRequest<PagedResult<MaintenanceScheduleDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
