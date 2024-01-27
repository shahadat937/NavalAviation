using MediatR;
using SchoolManagement.Application.DTOs.DemandType;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.DemandTypes.Requests.Queries
{
    public class GetDemandTypeListRequest : IRequest<PagedResult<DemandTypeDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
