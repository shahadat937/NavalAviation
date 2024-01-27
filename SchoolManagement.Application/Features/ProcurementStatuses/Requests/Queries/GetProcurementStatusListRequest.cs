using MediatR;
using SchoolManagement.Application.DTOs.ProcurementStatus;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.ProcurementStatuses.Requests.Queries
{
    public class GetProcurementStatusListRequest : IRequest<PagedResult<ProcurementStatusDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
