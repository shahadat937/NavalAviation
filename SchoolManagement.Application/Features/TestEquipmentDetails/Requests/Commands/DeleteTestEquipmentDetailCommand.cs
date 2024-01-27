using MediatR;

namespace SchoolManagement.Application.Features.TestEquipmentDetails.Requests.Commands
{
    public class DeleteTestEquipmentDetailCommand : IRequest
    {
        public int TestEquipmentDetailId { get; set; }
    }
}
