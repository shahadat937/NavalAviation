using MediatR;
using SchoolManagement.Application.DTOs.ShelfLifeCategory;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.ShelfLifeCategorys.Requests.Queries
{
    public class GetShelfLifeCategoryListRequest : IRequest<PagedResult<ShelfLifeCategoryDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
