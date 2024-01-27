using MediatR;
using SchoolManagement.Application.DTOs.AcStatus;

namespace SchoolManagement.Application.Features.AcStatuses.Requests.Queries
{
    public class GetAcStatusListByDepartmentIdRequest : IRequest<List<AcStatusDto>>
    {
        public int DepartmentNameId { get; set; }
    } 
}

