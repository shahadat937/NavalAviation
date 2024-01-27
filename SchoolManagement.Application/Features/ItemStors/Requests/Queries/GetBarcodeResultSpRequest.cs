using MediatR;

namespace SchoolManagement.Application.Features.ItemStors.Requests.Queries
{
    public class GetBarcodeResultSpRequest : IRequest<object>
    {
        public long ItemDetailId { get; set; }
    }
}
