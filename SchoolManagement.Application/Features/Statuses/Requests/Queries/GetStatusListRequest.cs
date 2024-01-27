using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.Status;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.Statuses.Requests.Queries
{
    public class GetStatusListRequest : IRequest<PagedResult<StatusDto>>
    {
        public QueryParams QueryParams { get; set; }
    } 
}
