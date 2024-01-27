using MediatR;
using SchoolManagement.Application.DTOs.ArchivingforPublication;

namespace SchoolManagement.Application.Features.ArchivingforPublications.Requests.Queries
{
    public class GetArchivingforPublicationDetailRequest : IRequest<ArchivingforPublicationDto>
    {
        public int ArchivingforPublicationId { get; set; }
    }
}
