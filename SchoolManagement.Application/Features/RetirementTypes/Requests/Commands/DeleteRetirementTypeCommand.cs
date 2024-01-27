using MediatR;

namespace SchoolManagement.Application.Features.RetirementTypes.Requests.Commands
{
    public class DeleteRetirementTypeCommand : IRequest
    {
        public int RetirementTypeId { get; set; }
    }
}
