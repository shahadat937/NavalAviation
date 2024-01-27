using MediatR;
using SchoolManagement.Application.DTOs.NameofPublication;

namespace SchoolManagement.Application.Features.NameofPublications.Requests.Queries
{
    public class GetNameofPublicationDetailRequest : IRequest<NameofPublicationDto>
    {
        public int NameofPublicationId { get; set; }
    }
}
