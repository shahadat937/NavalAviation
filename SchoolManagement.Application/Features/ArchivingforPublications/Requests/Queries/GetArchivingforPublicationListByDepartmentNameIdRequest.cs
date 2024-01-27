using MediatR;
using SchoolManagement.Application.DTOs.ArchivingforPublication;

namespace SchoolManagement.Application.Features.ArchivingforPublications.Requests.Queries
{
    public class GetArchivingforPublicationListByDepartmentNameIdRequest : IRequest<List<ArchivingforPublicationDto>>
    {
        
        public int DepartmentNameId { get; set; }
    } 
}

