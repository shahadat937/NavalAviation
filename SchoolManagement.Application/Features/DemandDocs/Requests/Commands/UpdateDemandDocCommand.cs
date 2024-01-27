using MediatR;
using SchoolManagement.Application.DTOs.DemandDocs;

namespace SchoolManagement.Application.Features.DemandDocs.Requests.Commands
{
    public class UpdateDemandDocCommand : IRequest<Unit>
    { 
        public DemandDocDto DemandDocDto { get; set; }
    }
}
 