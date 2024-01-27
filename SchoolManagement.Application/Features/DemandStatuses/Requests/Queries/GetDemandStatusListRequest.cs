using MediatR;
using SchoolManagement.Application.DTOs.DemandStatus;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.DemandStatuses.Requests.Queries
{
    public class GetDemandStatusListRequest : IRequest<PagedResult<DemandStatusDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
