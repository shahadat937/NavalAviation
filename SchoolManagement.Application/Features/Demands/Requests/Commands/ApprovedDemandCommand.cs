using MediatR;

namespace SchoolManagement.Application.Features.Demands.Requests.Commands
{
    public class ApprovedDemandCommand : IRequest 
    {
        public int DemandId { get; set; } 
    }
}
