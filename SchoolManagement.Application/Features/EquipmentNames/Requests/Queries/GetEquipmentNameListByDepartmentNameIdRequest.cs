using MediatR;
using SchoolManagement.Application.DTOs.EquipmentName;

namespace SchoolManagement.Application.Features.EquipmentNames.Requests.Queries
{
    public class GetEquipmentNameListByDepartmentNameIdRequest : IRequest<List<EquipmentNameDto>>
    {
        
        public int DepartmentNameId { get; set; }
    } 
}

 