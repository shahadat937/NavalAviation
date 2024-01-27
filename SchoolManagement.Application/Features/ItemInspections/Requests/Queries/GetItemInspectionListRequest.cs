using MediatR;
using SchoolManagement.Application.DTOs.ItemInspection;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.ItemInspections.Requests.Queries
{
    public class GetItemInspectionListRequest : IRequest<PagedResult<ItemInspectionDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
