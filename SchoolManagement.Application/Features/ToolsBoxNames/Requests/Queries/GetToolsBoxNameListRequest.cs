using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.ToolsBoxNames;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.ToolsBoxNames.Requests.Queries
{
    public class GetToolsBoxNameListRequest : IRequest<PagedResult<ToolsBoxNameDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
