using MediatR;
using SchoolManagement.Application.DTOs.Demands;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.Demands.Requests.Queries
{
    public class GetDemandListForSparesByDepartmentNameIdRequest : IRequest<PagedResult<DemandDto>>
    {
        public QueryParams QueryParams { get; set; }
        public int DepartmentNameId { get; set; }
        public int SparesCategoryId { get; set; }
        public int DemandTypeId { get; set; }

    } 
}

