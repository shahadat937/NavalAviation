using MediatR;
using SchoolManagement.Application.DTOs.DegitalArchieve;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.DegitalArchieves.Requests.Commands
{
    public class CreateDegitalArchieveCommand : IRequest<BaseCommandResponse>
    {
        public CreateDegitalArchieveDto DegitalArchieveDto { get; set; }
    }
}
