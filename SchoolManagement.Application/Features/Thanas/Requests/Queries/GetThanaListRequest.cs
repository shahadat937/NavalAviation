using SchoolManagement.Application.DTOs.Thana;
using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.Thanas.Requests.Queries
{
    public class GetThanaListRequest : IRequest<PagedResult<ThanaDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
