using MediatR;

namespace SchoolManagement.Application.Features.ArchivingforPublications.Requests.Commands
{
    public class DeleteArchivingforPublicationCommand : IRequest
    {
        public int ArchivingforPublicationId { get; set; }
    }
}
