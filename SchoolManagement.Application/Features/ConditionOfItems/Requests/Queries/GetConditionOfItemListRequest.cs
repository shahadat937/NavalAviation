using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.ConditionOfItems;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.ConditionOfItems.Requests.Queries
{
    public class GetConditionOfItemListRequest : IRequest<PagedResult<ConditionOfItemDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
