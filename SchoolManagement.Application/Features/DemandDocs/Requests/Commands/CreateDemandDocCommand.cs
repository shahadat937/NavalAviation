using MediatR;
using SchoolManagement.Application.DTOs.DemandDocs;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.DemandDocs.Requests.Commands
{
    public class CreateDemandDocCommand : IRequest<BaseCommandResponse>
    {
        public CreateDemandDocDto DemandDocDto { get; set; }
    }
}
