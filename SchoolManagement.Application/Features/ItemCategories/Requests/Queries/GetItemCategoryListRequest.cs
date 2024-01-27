using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.ItemCategorys;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.ItemCategories.Requests.Queries
{
    public class GetItemCategoryListRequest : IRequest<PagedResult<ItemCategoryDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
