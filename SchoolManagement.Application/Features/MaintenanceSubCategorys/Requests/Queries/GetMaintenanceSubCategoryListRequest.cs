using MediatR;
using SchoolManagement.Application.DTOs.MaintenanceSubCategory;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.MaintenanceSubCategorys.Requests.Queries
{
    public class GetMaintenanceSubCategoryListRequest : IRequest<PagedResult<MaintenanceSubCategoryDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
