using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.CallibrationState;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.CallibrationStates.Requests.Queries
{
    public class GetCallibrationStateListRequest : IRequest<PagedResult<CallibrationStateDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
