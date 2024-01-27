using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.PresentState;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.PresentStates.Requests.Queries
{
    public class GetPresentStateListRequest : IRequest<PagedResult<PresentStateDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
