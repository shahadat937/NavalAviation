using MediatR;
using SchoolManagement.Application.DTOs.ItemDetail;

namespace SchoolManagement.Application.Features.ItemDetails.Requests.Queries
{
    public class GetItemDetailDetailRequest : IRequest<ItemDetailDto>
    {
        public int ItemDetailId { get; set; }
    }
}
