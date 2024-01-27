using MediatR;
using SchoolManagement.Application.DTOs.RetirementType;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.RetirementTypes.Requests.Commands
{
    public class CreateRetirementTypeCommand : IRequest<BaseCommandResponse>
    {
        public CreateRetirementTypeDto RetirementTypeDto { get; set; }
    }
}
