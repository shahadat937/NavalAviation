using MediatR;
using SchoolManagement.Application.DTOs.SourceOfSupply;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.SourceOfSupplys.Requests.Queries
{
    public class GetSourceOfSupplyListRequest : IRequest<PagedResult<SourceOfSupplyDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
