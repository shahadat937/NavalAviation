using MediatR;
using SchoolManagement.Application.DTOs.Acceptances;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.Acceptances.Requests.Queries
{
    public class GetAcceptanceListByDepartmentNameIdRequest : IRequest<PagedResult<AcceptanceDto>>
    {
        public QueryParams QueryParams { get; set; }
        public int DepartmentNameId { get; set; }
        public int SparesCategoryId { get; set; }

    } 
}

 