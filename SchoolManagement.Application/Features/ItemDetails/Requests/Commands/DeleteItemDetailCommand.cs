using MediatR;

namespace SchoolManagement.Application.Features.ItemDetails.Requests.Commands
{
    public class DeleteItemDetailCommand : IRequest
    {
        public int ItemDetailId { get; set; }
    }
}
