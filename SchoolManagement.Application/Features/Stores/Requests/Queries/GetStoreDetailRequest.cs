using MediatR;
using SchoolManagement.Application.DTOs.Store;

namespace SchoolManagement.Application.Features.Stores.Requests.Queries
{
    public class GetStoreDetailRequest : IRequest<StoreDto>
    {
        public int StoreId { get; set; }
    }
}
