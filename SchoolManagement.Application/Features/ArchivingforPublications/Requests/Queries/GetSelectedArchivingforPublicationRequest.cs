using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.ArchivingforPublications.Requests.Queries
{
    public class GetSelectedArchivingforPublicationRequest : IRequest<List<SelectedModel>>
    {
    }
}
