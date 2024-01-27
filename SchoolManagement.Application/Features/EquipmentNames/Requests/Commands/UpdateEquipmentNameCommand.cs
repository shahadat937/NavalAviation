using MediatR;
using SchoolManagement.Application.DTOs.EquipmentName;

namespace SchoolManagement.Application.Features.EquipmentNames.Requests.Commands
{
    public class UpdateEquipmentNameCommand : IRequest<Unit>
    { 
        public EquipmentNameDto EquipmentNameDto { get; set; }
    }
}
