using MediatR;
using SchoolManagement.Application.DTOs.ItemDetail;

namespace SchoolManagement.Application.Features.ItemDetails.Requests.Commands
{
    public class UpdateItemDetailCommand : IRequest<Unit>
    {
        public ItemDetailDto ItemDetailDto { get; set; }
    }
}
