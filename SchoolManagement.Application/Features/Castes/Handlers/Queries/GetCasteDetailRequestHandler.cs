using AutoMapper;
using SchoolManagement.Application.DTOs.Caste;
using SchoolManagement.Application.Features.Castes.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;

namespace SchoolManagement.Application.Features.Castes.Handlers.Queries
{
    public class GetCasteDetailRequestHandler : IRequestHandler<GetCasteDetailRequest, CasteDto>
    {
        // private readonly IUTOfficerTypeRepository _UTOfficerTypeRepository;
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.Caste> _CasteRepository;
        public GetCasteDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.Caste> CasteRepository, IMapper mapper)
        {
            _CasteRepository = CasteRepository;
            _mapper = mapper;
        }
        public async Task<CasteDto> Handle(GetCasteDetailRequest request, CancellationToken cancellationToken)
        {
            var Caste = await _CasteRepository.Get(request.CasteId);
            return _mapper.Map<CasteDto>(Caste);
        }
    }
}
