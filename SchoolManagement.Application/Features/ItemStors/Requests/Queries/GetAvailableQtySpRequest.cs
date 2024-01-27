using MediatR;

namespace SchoolManagement.Application.Features.ItemStors.Requests.Queries
{
    public class GetAvailableQtyIssueDetailSpRequest : IRequest<object>
    {
        public int ItemDetailId { get; set; }
    }
}
