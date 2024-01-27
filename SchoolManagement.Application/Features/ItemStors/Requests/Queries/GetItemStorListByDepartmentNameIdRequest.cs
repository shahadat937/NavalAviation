using MediatR;
using SchoolManagement.Application.DTOs.ItemStor;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.ItemStors.Requests.Queries
{
    public class GetItemStorListByDepartmentNameIdRequest : IRequest<PagedResult<ItemStorDto>>
    {
        public QueryParams QueryParams { get; set; }
        public int DepartmentNameId { get; set; }
        public int SparesCategoryId { get; set; }
        public int Status { get; set; }
    }
}
