using MediatR;
using SchoolManagement.Application.DTOs.ToolsTypes;

namespace SchoolManagement.Application.Features.ToolsTypes.Requests.Queries
{
    public class GetToolsTypeDetailRequest : IRequest<ToolsTypeDto>
    {
        public int ToolsTypeId { get; set; }
    }
}
