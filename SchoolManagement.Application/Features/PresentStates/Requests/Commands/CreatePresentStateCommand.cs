using MediatR;
using SchoolManagement.Application.DTOs.PresentState;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.PresentStates.Requests.Commands
{
    public class CreatePresentStateCommand : IRequest<BaseCommandResponse>
    {
        public CreatePresentStateDto PresentStateDto { get; set; }
    }
}
