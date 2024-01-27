using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.NameofPublications.Requests.Queries
{
    public class GetSelectedNameofPublicationRequest : IRequest<List<SelectedModel>>
    {
    }
}
