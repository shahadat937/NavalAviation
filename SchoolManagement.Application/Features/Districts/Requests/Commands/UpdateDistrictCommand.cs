using SchoolManagement.Application.DTOs.District;
using MediatR;

namespace SchoolManagement.Application.Features.Districts.Requests.Commands
{
    public class UpdateDistrictCommand : IRequest<Unit>
    {
        public DistrictDto DistrictDto { get; set; }

    }
}
