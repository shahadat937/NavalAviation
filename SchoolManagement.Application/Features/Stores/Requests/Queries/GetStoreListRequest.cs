using MediatR;
using SchoolManagement.Application.DTOs.Store;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.Stores.Requests.Queries
{
    public class GetStoreListRequest : IRequest<PagedResult<StoreDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
