using MediatR;
using SchoolManagement.Application.DTOs.PartOfShipment;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.PartOfShipments.Requests.Queries
{
    public class GetPartOfShipmentListRequest : IRequest<PagedResult<PartOfShipmentDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
