using MediatR;
using SchoolManagement.Application.DTOs.MaintenenceState;

namespace SchoolManagement.Application.Features.MaintenenceStates.Requests.Queries
{
    public class GetMaintenenceStateDetailRequest : IRequest<MaintenenceStateDto>
    {
        public int MaintenenceStateId { get; set; }
    }
}
