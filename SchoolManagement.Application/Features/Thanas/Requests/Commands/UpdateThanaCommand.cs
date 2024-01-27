using SchoolManagement.Application.DTOs.Thana;
using MediatR;

namespace SchoolManagement.Application.Features.Thanas.Requests.Commands
{
    public class UpdateThanaCommand : IRequest<Unit>
    {
        public ThanaDto ThanaDto { get; set; }

    }
}
