using MediatR;

namespace SchoolManagement.Application.Features.DemandDocs.Requests.Commands
{
    public class DeleteDemandDocCommand : IRequest
    {
        public int DemandDocId { get; set; }
    }
} 
