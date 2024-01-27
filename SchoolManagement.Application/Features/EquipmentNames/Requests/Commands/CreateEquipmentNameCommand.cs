using MediatR;
using SchoolManagement.Application.DTOs.EquipmentName;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.EquipmentNames.Requests.Commands
{
    public class CreateEquipmentNameCommand : IRequest<BaseCommandResponse>
    {
        public CreateEquipmentNameDto EquipmentNameDto { get; set; }
    }
}
