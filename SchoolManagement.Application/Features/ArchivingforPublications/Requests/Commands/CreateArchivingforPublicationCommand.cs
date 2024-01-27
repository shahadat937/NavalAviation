using MediatR;
using SchoolManagement.Application.DTOs.ArchivingforPublication;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.ArchivingforPublications.Requests.Commands
{
    public class CreateArchivingforPublicationCommand : IRequest<BaseCommandResponse>
    {
        public CreateArchivingforPublicationDto ArchivingforPublicationDto { get; set; }
    }
}
