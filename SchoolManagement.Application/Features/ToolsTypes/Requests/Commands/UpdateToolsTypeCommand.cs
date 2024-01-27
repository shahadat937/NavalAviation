using MediatR;
using SchoolManagement.Application.DTOs.ToolsTypes;

namespace SchoolManagement.Application.Features.ToolsTypes.Requests.Commands
{
    public class UpdateToolsTypeCommand : IRequest<Unit>
    { 
        public ToolsTypeDto ToolsTypeDto { get; set; }
    }
}
