using MediatR;
using SchoolManagement.Application.DTOs.EndLifeTypes;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.EndLifeTypes.Requests.Commands
{
    public class CreateEndLifeTypeCommand : IRequest<BaseCommandResponse>
    {
        public CreateEndLifeTypeDto EndLifeTypeDto { get; set; }
    }
}
