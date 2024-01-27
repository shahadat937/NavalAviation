using MediatR;
using SchoolManagement.Application.DTOs.RetirementType;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.RetirementTypes.Requests.Queries
{
    public class GetRetirementTypeListRequest : IRequest<PagedResult<RetirementTypeDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
