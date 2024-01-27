using MediatR;
using SchoolManagement.Application.DTOs.AcctStores;

namespace SchoolManagement.Application.Features.AcctStores.Requests.Queries
{
    public class GetAcctStoreDetailRequest : IRequest<AcctStoreDto>
    {
        public int AcctStoreId { get; set; }
    }
}
