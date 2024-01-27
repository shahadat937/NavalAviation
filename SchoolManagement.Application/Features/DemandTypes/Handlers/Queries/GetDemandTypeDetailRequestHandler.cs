using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.DemandType;
using SchoolManagement.Application.Features.DemandTypes.Requests.Queries;

namespace SchoolManagement.Application.Features.DemandTypes.Handlers.Queries
{
    public class GetDemandTypeDetailRequestHandler : IRequestHandler<GetDemandTypeDetailRequest, DemandTypeDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.DemandType> _DemandTypeRepository;
        public GetDemandTypeDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.DemandType> DemandTypeRepository, IMapper mapper)
        {
            _DemandTypeRepository = DemandTypeRepository;
            _mapper = mapper;
        }
        public async Task<DemandTypeDto> Handle(GetDemandTypeDetailRequest request, CancellationToken cancellationToken)
        {
            var DemandType = await _DemandTypeRepository.Get(request.DemandTypeId);
            return _mapper.Map<DemandTypeDto>(DemandType);
        }
    }
}
