using MediatR;
using SchoolManagement.Application.DTOs.Acceptances;

namespace SchoolManagement.Application.Features.Acceptances.Requests.Queries
{
    public class GetAcceptanceDetailRequest : IRequest<AcceptanceDto>
    {
        public int AcceptanceId { get; set; }
    }
}
