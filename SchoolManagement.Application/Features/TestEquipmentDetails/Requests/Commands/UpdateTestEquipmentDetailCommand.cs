using SchoolManagement.Application.DTOs.TestEquipmentDetail;
using MediatR;

namespace SchoolManagement.Application.Features.TestEquipmentDetails.Requests.Commands
{
    public class UpdateTestEquipmentDetailCommand : IRequest<Unit>
    {
        public TestEquipmentDetailDto TestEquipmentDetailDto { get; set; }

    }
}
