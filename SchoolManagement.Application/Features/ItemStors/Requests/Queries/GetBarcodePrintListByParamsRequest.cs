using MediatR;
using SchoolManagement.Application.DTOs.Demands;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;
using SchoolManagement.Application.DTOs.ItemStor;

namespace SchoolManagement.Application.Features.ItemStors.Requests.Queries
{
    public class GetBarcodePrintListByParamsRequest : IRequest<PagedResult<ItemStorDto>>
    {
        public QueryParams QueryParams { get; set; }
        public int DepartmentNameId { get; set; }
        public int SparesCategoryId { get; set; }

    } 
}

