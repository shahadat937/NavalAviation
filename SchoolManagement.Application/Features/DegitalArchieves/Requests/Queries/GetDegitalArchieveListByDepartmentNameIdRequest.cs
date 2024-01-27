using MediatR;
using SchoolManagement.Application.DTOs.DegitalArchieve;

namespace SchoolManagement.Application.Features.DegitalArchieves.Requests.Queries
{
    public class GetDegitalArchieveListByDepartmentNameIdRequest : IRequest<List<DegitalArchieveDto>>
    {
        
        public int DepartmentNameId { get; set; }
    } 
}

