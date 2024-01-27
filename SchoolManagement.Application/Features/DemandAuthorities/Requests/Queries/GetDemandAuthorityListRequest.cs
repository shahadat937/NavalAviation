using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.DemandAuthority; 
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.DemandAuthorities.Requests.Queries
{
    public class GetDemandAuthorityListRequest : IRequest<PagedResult<DemandAuthorityDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
