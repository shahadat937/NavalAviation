using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.MaintenenceState;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.MaintenenceStates.Requests.Queries
{
    public class GetMaintenenceStateListRequest : IRequest<PagedResult<MaintenenceStateDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
