using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.SparesCategorys;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.SparesCategories.Requests.Queries
{
    public class GetSparesCategoryListRequest : IRequest<PagedResult<SparesCategoryDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
