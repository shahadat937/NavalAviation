using MediatR;

namespace SchoolManagement.Application.Features.DemandTypes.Requests.Commands
{
    public class DeleteDemandTypeCommand : IRequest
    {
        public int DemandTypeId { get; set; }
    }
}
