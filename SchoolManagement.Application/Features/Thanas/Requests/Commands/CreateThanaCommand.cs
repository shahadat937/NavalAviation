using SchoolManagement.Application.DTOs.Thana;
using SchoolManagement.Application.Responses;
using MediatR;

namespace SchoolManagement.Application.Features.Thanas.Requests.Commands
{
    public class CreateThanaCommand : IRequest<BaseCommandResponse>
    {
        public CreateThanaDto ThanaDto { get; set; }

    }
}
