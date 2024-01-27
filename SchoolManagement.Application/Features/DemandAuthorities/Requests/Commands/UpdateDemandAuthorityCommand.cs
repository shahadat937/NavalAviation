using MediatR;
using SchoolManagement.Application.DTOs.DemandAuthority;

namespace SchoolManagement.Application.Features.DemandAuthorities.Requests.Commands
{
    public class UpdateDemandAuthorityCommand : IRequest<Unit>  
    { 
        public DemandAuthorityDto DemandAuthorityDto { get; set; }
    }
}
 