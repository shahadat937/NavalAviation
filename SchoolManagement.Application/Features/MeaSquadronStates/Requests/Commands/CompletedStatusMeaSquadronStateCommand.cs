using MediatR;

namespace SchoolManagement.Application.Features.MeaSquadronStates.Requests.Commands
{
    public class CompletedStatusMeaSquadronStateCommand : IRequest 
    {
        public int MeaSquadronStateId { get; set; } 
    }
}
