using MediatR;
using SchoolManagement.Application.DTOs.DemandAuthority;

namespace SchoolManagement.Application.Features.DemandAuthorities.Requests.Queries
{
    public class GetDemandAuthorityDetailRequest : IRequest<DemandAuthorityDto>
    {
        public int DemandAuthorityId { get; set; } 
    }
}
