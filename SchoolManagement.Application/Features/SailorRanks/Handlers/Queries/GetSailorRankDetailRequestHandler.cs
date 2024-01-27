using AutoMapper;
using SchoolManagement.Application.DTOs.SailorRank;
using SchoolManagement.Application.Features.SailorRanks.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;

namespace SchoolManagement.Application.Features.SailorRanks.Handlers.Queries
{
    public class GetSailorRankDetailRequestHandler : IRequestHandler<GetSailorRankDetailRequest, SailorRankDto>
    {
        // private readonly IUTOfficerTypeRepository _UTOfficerTypeRepository;
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.SailorRank> _SailorRankRepository;
        public GetSailorRankDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.SailorRank> SailorRankRepository, IMapper mapper)
        {
            _SailorRankRepository = SailorRankRepository;
            _mapper = mapper;
        }
        public async Task<SailorRankDto> Handle(GetSailorRankDetailRequest request, CancellationToken cancellationToken)
        {
            var SailorRank = await _SailorRankRepository.Get(request.SailorRankId);
            return _mapper.Map<SailorRankDto>(SailorRank);
        }
    }
}
