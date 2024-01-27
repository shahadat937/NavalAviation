using MediatR;
using SchoolManagement.Application.DTOs.GseItemName;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.GseItemNames.Requests.Queries
{
    public class GetGseItemNameListRequest : IRequest<PagedResult<GseItemNameDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
