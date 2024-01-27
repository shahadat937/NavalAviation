using MediatR;
using SchoolManagement.Application.DTOs.PresentBillets;

namespace SchoolManagement.Application.Features.PresentBillets.Requests.Commands
{
    public class UpdatePresentBilletCommand : IRequest<Unit>
    { 
        public PresentBilletDto PresentBilletDto { get; set; }
    }
}
