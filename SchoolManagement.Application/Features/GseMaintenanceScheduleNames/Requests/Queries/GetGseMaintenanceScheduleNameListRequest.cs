using MediatR;
using SchoolManagement.Application.DTOs.GseMaintenanceScheduleName;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.GseMaintenanceScheduleNames.Requests.Queries
{
    public class GetGseMaintenanceScheduleNameListRequest : IRequest<PagedResult<GseMaintenanceScheduleNameDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
