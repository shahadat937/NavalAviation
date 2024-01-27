using MediatR;

namespace SchoolManagement.Application.Features.ItemDetails.Requests.Commands
{
    public class ApprovedItemDetailCommand : IRequest 
    {
        public int ItemDetailId { get; set; } 
    }
}
