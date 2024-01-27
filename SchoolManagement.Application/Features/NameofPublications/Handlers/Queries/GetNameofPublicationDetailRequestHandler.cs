using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.NameofPublication;
using SchoolManagement.Application.Features.NameofPublications.Requests.Queries;

namespace SchoolManagement.Application.Features.NameofPublications.Handlers.Queries
{
    public class GetNameofPublicationDetailRequestHandler : IRequestHandler<GetNameofPublicationDetailRequest, NameofPublicationDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.NameofPublication> _NameofPublicationRepository;
        public GetNameofPublicationDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.NameofPublication> NameofPublicationRepository, IMapper mapper)
        {
            _NameofPublicationRepository = NameofPublicationRepository;
            _mapper = mapper;
        }
        public async Task<NameofPublicationDto> Handle(GetNameofPublicationDetailRequest request, CancellationToken cancellationToken)
        {
            var NameofPublication = await _NameofPublicationRepository.Get(request.NameofPublicationId);
            return _mapper.Map<NameofPublicationDto>(NameofPublication);
        }
    }
}
