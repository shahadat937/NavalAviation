using MediatR;
using SchoolManagement.Application.DTOs.NameofPublication;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.NameofPublications.Requests.Commands
{
    public class CreateNameofPublicationCommand : IRequest<BaseCommandResponse>
    {
        public CreateNameofPublicationDto NameofPublicationDto { get; set; }
    }
}
