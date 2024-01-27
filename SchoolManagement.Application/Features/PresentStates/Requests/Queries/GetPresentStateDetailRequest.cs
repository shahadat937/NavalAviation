using MediatR;
using SchoolManagement.Application.DTOs.PresentState;

namespace SchoolManagement.Application.Features.PresentStates.Requests.Queries
{
    public class GetPresentStateDetailRequest : IRequest<PresentStateDto>
    {
        public int PresentStateId { get; set; }
    }
}
