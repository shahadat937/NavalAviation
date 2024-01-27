using SchoolManagement.Application.DTOs.TestEquipmentDetail;
using MediatR;

namespace SchoolManagement.Application.Features.TestEquipmentDetails.Requests.Queries
{
    public class GetTestEquipmentDetailDetailRequest : IRequest<TestEquipmentDetailDto>
    {
        public int TestEquipmentDetailId { get; set; }
    }
}
