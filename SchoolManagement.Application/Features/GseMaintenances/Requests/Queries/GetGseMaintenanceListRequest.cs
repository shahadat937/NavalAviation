using MediatR;
using SchoolManagement.Application.DTOs.GseMaintenance;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.GseMaintenances.Requests.Queries
{
    public class GetGseMaintenanceListRequest : IRequest<PagedResult<GseMaintenanceDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
