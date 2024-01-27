using MediatR;
using SchoolManagement.Application.DTOs.DemandAuthority;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.DemandAuthorities.Requests.Commands
{
    public class CreateDemandAuthorityCommand : IRequest<BaseCommandResponse>
    {
        public CreateDemandAuthorityDto DemandAuthorityDto { get; set; } 
    }
} 
