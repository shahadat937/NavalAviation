using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.ItemTypes;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.ItemTypes.Requests.Queries
{
    public class GetItemTypeListRequest : IRequest<PagedResult<ItemTypeDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
