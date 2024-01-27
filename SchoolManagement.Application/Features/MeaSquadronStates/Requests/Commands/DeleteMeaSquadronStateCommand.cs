using MediatR;

namespace SchoolManagement.Application.Features.MeaSquadronStates.Requests.Commands
{
    public class DeleteMeaSquadronStateCommand : IRequest
    {
        public int MeaSquadronStateId { get; set; }
    }
} 
