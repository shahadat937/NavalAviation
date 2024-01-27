using MediatR;
using SchoolManagement.Application.DTOs.RetirementType;

namespace SchoolManagement.Application.Features.RetirementTypes.Requests.Commands
{
    public class UpdateRetirementTypeCommand : IRequest<Unit>
    {
        public RetirementTypeDto RetirementTypeDto { get; set; }
    }
}
