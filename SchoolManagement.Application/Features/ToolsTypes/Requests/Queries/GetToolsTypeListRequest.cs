using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.ToolsTypes;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.ToolsTypes.Requests.Queries
{
    public class GetToolsTypeListRequest : IRequest<PagedResult<ToolsTypeDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
