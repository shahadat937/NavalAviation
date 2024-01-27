using MediatR;
using SchoolManagement.Application.DTOs.MaintenancePlanning;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.MaintenancePlannings.Requests.Queries
{
    public class GetMaintenancePlanningListRequest : IRequest<PagedResult<MaintenancePlanningDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
