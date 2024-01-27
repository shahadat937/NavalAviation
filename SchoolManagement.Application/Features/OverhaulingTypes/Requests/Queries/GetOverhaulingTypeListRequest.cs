using MediatR;
using SchoolManagement.Application.DTOs.OverhaulingType;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.OverhaulingTypes.Requests.Queries
{
    public class GetOverhaulingTypeListRequest : IRequest<PagedResult<OverhaulingTypeDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
