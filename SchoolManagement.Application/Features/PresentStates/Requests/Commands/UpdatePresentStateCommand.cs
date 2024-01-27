using MediatR;
using SchoolManagement.Application.DTOs.PresentState;

namespace SchoolManagement.Application.Features.PresentStates.Requests.Commands
{
    public class UpdatePresentStateCommand : IRequest<Unit>
    { 
        public PresentStateDto PresentStateDto { get; set; }
    }
}
 