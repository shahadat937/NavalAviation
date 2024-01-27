using MediatR;
using SchoolManagement.Application.DTOs.CallibrationState;

namespace SchoolManagement.Application.Features.CallibrationStates.Requests.Queries
{
    public class GetCallibrationStateDetailRequest : IRequest<CallibrationStateDto>
    {
        public int CallibrationStateId { get; set; }
    }
}
