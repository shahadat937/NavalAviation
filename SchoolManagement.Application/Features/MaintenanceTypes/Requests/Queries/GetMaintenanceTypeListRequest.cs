using MediatR;
using SchoolManagement.Application.DTOs.MaintenanceType;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.MaintenanceTypes.Requests.Queries
{
    public class GetMaintenanceTypeListRequest : IRequest<PagedResult<MaintenanceTypeDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
