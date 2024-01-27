using MediatR;
using SchoolManagement.Application.DTOs.AcStatus;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.AcStatuses.Requests.Queries
{
    public class GetAcStatusListRequest : IRequest<PagedResult<AcStatusDto>> 
    {
        public QueryParams QueryParams { get; set; }
    }
}
