using MediatR;
using SchoolManagement.Application.DTOs.LifeLimitItem;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.LifeLimitItems.Requests.Queries
{
    public class GetLifeLimitItemListRequest : IRequest<PagedResult<LifeLimitItemDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
