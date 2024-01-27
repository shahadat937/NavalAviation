using MediatR;
using SchoolManagement.Application.DTOs.ItemDetail;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.ItemDetails.Requests.Queries
{
    public class GetItemDetailListRequest : IRequest<PagedResult<ItemDetailDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
