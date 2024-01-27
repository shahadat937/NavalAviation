using MediatR;
using SchoolManagement.Application.DTOs.ToolsTypes;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.ToolsTypes.Requests.Commands
{
    public class CreateToolsTypeCommand : IRequest<BaseCommandResponse>
    {
        public CreateToolsTypeDto ToolsTypeDto { get; set; }
    }
}
