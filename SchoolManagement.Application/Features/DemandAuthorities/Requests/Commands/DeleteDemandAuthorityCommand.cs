using MediatR;

namespace SchoolManagement.Application.Features.DemandAuthorities.Requests.Commands
{
    public class DeleteDemandAuthorityCommand : IRequest 
    {
        public int DemandAuthorityId { get; set; }
    }
} 
