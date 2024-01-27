using MediatR;
using SchoolManagement.Application.DTOs.EquipmentName;

namespace SchoolManagement.Application.Features.EquipmentNames.Requests.Queries
{
    public class GetEquipmentNameDetailRequest : IRequest<EquipmentNameDto>
    {
        public int EquipmentNameId { get; set; }
    }
}
