using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using SchoolManagement.Application.DTOs.ArchivingforPublication;
using SchoolManagement.Application.Features.ArchivingforPublications.Requests.Queries;

namespace SchoolManagement.Application.Features.ArchivingforPublications.Handlers.Queries
{
    public class GetArchivingforPublicationListByDepartmentNameIdRequestHandler : IRequestHandler<GetArchivingforPublicationListByDepartmentNameIdRequest, List<ArchivingforPublicationDto>>
    {
        private readonly ISchoolManagementRepository<ArchivingforPublication> _ArchivingforPublicationRepository;

        private readonly IMapper _mapper;
        public GetArchivingforPublicationListByDepartmentNameIdRequestHandler(ISchoolManagementRepository<ArchivingforPublication> ArchivingforPublicationRepository, IMapper mapper)
        {
            _ArchivingforPublicationRepository = ArchivingforPublicationRepository;
            _mapper = mapper;
        }

        public async Task<List<ArchivingforPublicationDto>> Handle(GetArchivingforPublicationListByDepartmentNameIdRequest request, CancellationToken cancellationToken)
        {
            IQueryable<ArchivingforPublication> ArchivingforPublications = _ArchivingforPublicationRepository.FilterWithInclude(x => x.DepartmentNameId == (request.DepartmentNameId == 0 ? x.DepartmentNameId : request.DepartmentNameId) , "DepartmentName", "AirCraftName", "NameofPublication");
            var totalCount = ArchivingforPublications.Count();
            ArchivingforPublications = ArchivingforPublications.OrderByDescending(x => x.ArchivingforPublicationId);
            var ArchivingforPublicationDtos = _mapper.Map<List<ArchivingforPublicationDto>>(ArchivingforPublications);

            return ArchivingforPublicationDtos;
        }

    }
}
