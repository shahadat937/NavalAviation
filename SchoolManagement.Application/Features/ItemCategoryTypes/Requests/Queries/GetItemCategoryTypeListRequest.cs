using MediatR;
using SchoolManagement.Application.DTOs.ItemCategoryType;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.ItemCategoryTypes.Requests.Queries
{
    public class GetItemCategoryTypeListRequest : IRequest<PagedResult<ItemCategoryTypeDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
