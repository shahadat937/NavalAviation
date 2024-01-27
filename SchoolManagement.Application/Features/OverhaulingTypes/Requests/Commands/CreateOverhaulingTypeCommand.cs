using MediatR;
using SchoolManagement.Application.DTOs.OverhaulingType;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.OverhaulingTypes.Requests.Commands
{
    public class CreateOverhaulingTypeCommand : IRequest<BaseCommandResponse>
    {
        public CreateOverhaulingTypeDto OverhaulingTypeDto { get; set; }
    }
}
