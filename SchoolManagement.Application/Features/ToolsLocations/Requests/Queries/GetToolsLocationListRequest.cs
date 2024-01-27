using MediatR;
using SchoolManagement.Application.DTOs.ToolsLocation;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.ToolsLocations.Requests.Queries
{
    public class GetToolsLocationListRequest : IRequest<PagedResult<ToolsLocationDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
} 
