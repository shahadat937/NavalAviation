using MediatR;
using SchoolManagement.Application.DTOs.DegitalArchieve;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.DegitalArchieves.Requests.Queries
{
    public class GetDegitalArchieveListRequest : IRequest<PagedResult<DegitalArchieveDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
