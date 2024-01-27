using MediatR;
using SchoolManagement.Application.DTOs.PlaceOfDelivery;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.PlaceOfDeliverys.Requests.Queries
{
    public class GetPlaceOfDeliveryListRequest : IRequest<PagedResult<PlaceOfDeliveryDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
