using MediatR;
using SchoolManagement.Application.DTOs.ToolsBoxNames;

namespace SchoolManagement.Application.Features.ToolsBoxNames.Requests.Queries
{
    public class GetToolsBoxNameDetailRequest : IRequest<ToolsBoxNameDto>
    {
        public int ToolsBoxNameId { get; set; }
    }
}
 