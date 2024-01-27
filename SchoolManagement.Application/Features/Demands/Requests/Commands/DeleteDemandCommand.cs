using MediatR;

namespace SchoolManagement.Application.Features.Demands.Requests.Commands
{
    public class DeleteDemandCommand : IRequest
    {
        public int DemandId { get; set; }
    }
} 
