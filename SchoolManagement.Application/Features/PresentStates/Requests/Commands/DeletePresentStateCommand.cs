using MediatR;

namespace SchoolManagement.Application.Features.PresentStates.Requests.Commands
{
    public class DeletePresentStateCommand : IRequest
    {
        public int PresentStateId { get; set; }
    }
} 
