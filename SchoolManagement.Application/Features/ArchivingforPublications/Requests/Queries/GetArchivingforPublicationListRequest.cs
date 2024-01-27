using MediatR;
using SchoolManagement.Application.DTOs.ArchivingforPublication;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.ArchivingforPublications.Requests.Queries
{
    public class GetArchivingforPublicationListRequest : IRequest<PagedResult<ArchivingforPublicationDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
