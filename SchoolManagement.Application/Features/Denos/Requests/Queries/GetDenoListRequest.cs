using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.Denos;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.Denos.Requests.Queries
{
    public class GetDenoListRequest : IRequest<PagedResult<DenoDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
