using SchoolManagement.Application.DTOs.TestEquipmentDetail;
using SchoolManagement.Application.Responses;
using MediatR;

namespace SchoolManagement.Application.Features.TestEquipmentDetails.Requests.Commands
{
    public class CreateTestEquipmentDetailCommand : IRequest<BaseCommandResponse>
    {
        public CreateTestEquipmentDetailDto TestEquipmentDetailDto { get; set; }

    }
}
