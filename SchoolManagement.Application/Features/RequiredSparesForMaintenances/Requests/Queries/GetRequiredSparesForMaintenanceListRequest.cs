using MediatR;
using SchoolManagement.Application.DTOs.RequiredSparesForMaintenance;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.RequiredSparesForMaintenances.Requests.Queries
{
    public class GetRequiredSparesForMaintenanceListRequest : IRequest<PagedResult<RequiredSparesForMaintenanceDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
