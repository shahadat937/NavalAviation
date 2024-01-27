using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.DemandCompleteStatuses;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.DemandCompleteStatuses.Requests.Queries
{
    public class GetDemandCompleteStatusListRequest : IRequest<PagedResult<DemandCompleteStatusDto>> 
    {
        public QueryParams QueryParams { get; set; }
    }
}
