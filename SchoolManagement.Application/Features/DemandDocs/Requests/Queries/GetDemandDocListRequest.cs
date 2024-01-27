using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.DemandDocs;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.DemandDocs.Requests.Queries
{
    public class GetDemandDocListRequest : IRequest<PagedResult<DemandDocDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
