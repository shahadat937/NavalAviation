using MediatR;

namespace SchoolManagement.Application.Features.PresentBillets.Requests.Commands
{
    public class DeletePresentBilletCommand : IRequest
    {
        public int PresentBilletId { get; set; }
    }
} 
