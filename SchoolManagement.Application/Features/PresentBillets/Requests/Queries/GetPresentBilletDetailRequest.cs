using MediatR;
using SchoolManagement.Application.DTOs.PresentBillets;

namespace SchoolManagement.Application.Features.PresentBillets.Requests.Queries
{
    public class GetPresentBilletDetailRequest : IRequest<PresentBilletDto>
    {
        public int PresentBilletId { get; set; }
    }
}
