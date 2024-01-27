using MediatR;
using SchoolManagement.Application.DTOs.PresentBillets;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.PresentBillets.Requests.Commands
{
    public class CreatePresentBilletCommand : IRequest<BaseCommandResponse>
    {
        public CreatePresentBilletDto PresentBilletDto { get; set; }
    }
}
