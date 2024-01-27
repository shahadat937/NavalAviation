using MediatR;
using SchoolManagement.Application.DTOs.PreviousItemStore;

namespace SchoolManagement.Application.Features.PreviousItemStores.Requests.Queries
{
    public class GetPreviousItemStoreDetailRequest : IRequest<PreviousItemStoreDto>
    {
        public int PreviousItemStoreId { get; set; }
    }
}
