using MediatR;
using SchoolManagement.Application.DTOs.ItemInspection;

namespace SchoolManagement.Application.Features.ItemInspections.Requests.Queries
{
    public class GetItemInspectionDetailRequest : IRequest<ItemInspectionDto>
    {
        public int ItemInspectionId { get; set; }
    }
}
