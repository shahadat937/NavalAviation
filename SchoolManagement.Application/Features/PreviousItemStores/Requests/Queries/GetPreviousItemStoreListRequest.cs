using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.PreviousItemStore;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.PreviousItemStores.Requests.Queries
{
    public class GetPreviousItemStoreListRequest : IRequest<PagedResult<PreviousItemStoreDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
