using MediatR;
using SchoolManagement.Application.DTOs.Manufacture;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.Manufactures.Requests.Queries
{
    public class GetManufactureListRequest : IRequest<PagedResult<ManufactureDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
