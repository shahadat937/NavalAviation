using MediatR;
using SchoolManagement.Application.DTOs.Denos;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.Denos.Requests.Commands
{
    public class CreateDenoCommand : IRequest<BaseCommandResponse>
    {
        public CreateDenoDto DenoDto { get; set; }
    }
}
