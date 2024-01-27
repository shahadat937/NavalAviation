using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.DemandDocs;
using SchoolManagement.Application.Features.DemandDocs.Requests.Queries;

namespace SchoolManagement.Application.Features.DemandDocs.Handlers.Queries
{
    public class GetDemandDocDetailRequestHandler : IRequestHandler<GetDemandDocDetailRequest, DemandDocDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.DemandDoc> _DemandDocRepository;
        public GetDemandDocDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.DemandDoc> DemandDocRepository, IMapper mapper)
        {
            _DemandDocRepository = DemandDocRepository;
            _mapper = mapper;
        }
        public async Task<DemandDocDto> Handle(GetDemandDocDetailRequest request, CancellationToken cancellationToken)
        {
            var DemandDoc = await _DemandDocRepository.Get(request.DemandDocId);
            return _mapper.Map<DemandDocDto>(DemandDoc);
        }
    }
}
