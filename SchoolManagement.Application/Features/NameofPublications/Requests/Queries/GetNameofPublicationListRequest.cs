using MediatR;
using SchoolManagement.Application.DTOs.NameofPublication;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.NameofPublications.Requests.Queries
{
    public class GetNameofPublicationListRequest : IRequest<PagedResult<NameofPublicationDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
