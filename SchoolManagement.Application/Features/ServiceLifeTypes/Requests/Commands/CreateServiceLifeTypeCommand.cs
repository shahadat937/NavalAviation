using MediatR;
using SchoolManagement.Application.DTOs.ServiceLifeTypes;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.ServiceLifeTypes.Requests.Commands
{
    public class CreateServiceLifeTypeCommand : IRequest<BaseCommandResponse>
    {
        public CreateServiceLifeTypeDto ServiceLifeTypeDto { get; set; }
    }
}
