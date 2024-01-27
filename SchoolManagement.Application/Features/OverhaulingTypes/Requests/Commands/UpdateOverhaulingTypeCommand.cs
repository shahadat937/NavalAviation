using MediatR;
using SchoolManagement.Application.DTOs.OverhaulingType;

namespace SchoolManagement.Application.Features.OverhaulingTypes.Requests.Commands
{
    public class UpdateOverhaulingTypeCommand : IRequest<Unit>
    {
        public OverhaulingTypeDto OverhaulingTypeDto { get; set; }
    }
}
