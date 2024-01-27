using MediatR;

namespace SchoolManagement.Application.Features.Procurements.Requests.Commands
{
    public class ApprovedProcurementCommand : IRequest 
    {
        public int ProcurementId { get; set; } 
    }
}
