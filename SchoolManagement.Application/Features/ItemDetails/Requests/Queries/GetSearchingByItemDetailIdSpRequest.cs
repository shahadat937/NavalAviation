using MediatR;

namespace SchoolManagement.Application.Features.ItemDetails.Requests.Queries
{
    public class GetSearchingByItemDetailIdSpRequest : IRequest<object>
    {
        public int ItemDetailId { get; set; }
  }
}
