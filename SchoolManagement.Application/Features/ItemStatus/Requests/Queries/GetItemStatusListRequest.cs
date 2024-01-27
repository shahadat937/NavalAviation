using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.ItemStatuses;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.ItemStatuses.Requests.Queries
{
    public class GetItemStatusListRequest : IRequest<PagedResult<ItemStatusDto>> 
    {
        public QueryParams QueryParams { get; set; }
    }
}
