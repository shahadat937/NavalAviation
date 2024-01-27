using MediatR;

namespace SchoolManagement.Application.Features.Acceptances.Requests.Commands
{
    public class ApprovedAcceptanceCommand : IRequest 
    {
        public int AcceptanceId { get; set; } 
    }
}
