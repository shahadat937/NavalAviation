using MediatR;
using SchoolManagement.Application.DTOs.MaintenancePlanningStatus;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.MaintenancePlanningStatuses.Requests.Queries
{
    public class GetMaintenancePlanningStatusListRequest : IRequest<PagedResult<MaintenancePlanningStatusDto>> 
    {
        public QueryParams QueryParams { get; set; }
    }
}
