using MediatR;

namespace SchoolManagement.Application.Features.NameofPublications.Requests.Commands
{
    public class DeleteNameofPublicationCommand : IRequest
    {
        public int NameofPublicationId { get; set; }
    }
}
