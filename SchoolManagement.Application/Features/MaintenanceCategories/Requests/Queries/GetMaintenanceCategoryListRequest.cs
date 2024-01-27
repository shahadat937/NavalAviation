using MediatR;
using SchoolManagement.Application.DTOs.MaintenanceCategory;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.MaintenanceCategories.Requests.Queries
{
    public class GetMaintenanceCategoryListRequest : IRequest<PagedResult<MaintenanceCategoryDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
