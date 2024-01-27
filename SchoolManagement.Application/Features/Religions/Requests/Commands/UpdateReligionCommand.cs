using SchoolManagement.Application.DTOs.Religion;
using MediatR;

namespace SchoolManagement.Application.Features.Religions.Requests.Commands
{
    public class UpdateReligionCommand : IRequest<Unit>
    {
        public ReligionDto ReligionDto { get; set; }

    }
}
