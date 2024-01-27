using SchoolManagement.Application.DTOs.Religion;
using SchoolManagement.Application.Responses;
using MediatR;

namespace SchoolManagement.Application.Features.Religions.Requests.Commands
{
    public class CreateReligionCommand : IRequest<BaseCommandResponse>
    {
        public CreateReligionDto ReligionDto { get; set; }

    }
}
