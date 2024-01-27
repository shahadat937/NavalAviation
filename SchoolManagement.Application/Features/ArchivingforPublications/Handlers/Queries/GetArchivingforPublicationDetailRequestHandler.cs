using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ArchivingforPublication;
using SchoolManagement.Application.Features.ArchivingforPublications.Requests.Queries;

namespace SchoolManagement.Application.Features.ArchivingforPublications.Handlers.Queries
{
    public class GetArchivingforPublicationDetailRequestHandler : IRequestHandler<GetArchivingforPublicationDetailRequest, ArchivingforPublicationDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.ArchivingforPublication> _ArchivingforPublicationRepository;
        public GetArchivingforPublicationDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.ArchivingforPublication> ArchivingforPublicationRepository, IMapper mapper)
        {
            _ArchivingforPublicationRepository = ArchivingforPublicationRepository;
            _mapper = mapper;
        }
        public async Task<ArchivingforPublicationDto> Handle(GetArchivingforPublicationDetailRequest request, CancellationToken cancellationToken)
        {
            var ArchivingforPublication = await _ArchivingforPublicationRepository.Get(request.ArchivingforPublicationId);
            return _mapper.Map<ArchivingforPublicationDto>(ArchivingforPublication);
        }
    }
}
