using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.OverhaulingType;
using SchoolManagement.Application.Features.OverhaulingTypes.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.OverhaulingTypes.Handlers.Queries
{
    public class GetOverhaulingTypeDetailRequestHandler : IRequestHandler<GetOverhaulingTypeDetailRequest, OverhaulingTypeDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<OverhaulingType> _OverhaulingTypeRepository;
        public GetOverhaulingTypeDetailRequestHandler(ISchoolManagementRepository<OverhaulingType> OverhaulingTypeRepository, IMapper mapper)
        {
            _OverhaulingTypeRepository = OverhaulingTypeRepository;
            _mapper = mapper;
        }
        public async Task<OverhaulingTypeDto> Handle(GetOverhaulingTypeDetailRequest request, CancellationToken cancellationToken)
        {
            var OverhaulingType = await _OverhaulingTypeRepository.Get(request.OverhaulingTypeId);
            return _mapper.Map<OverhaulingTypeDto>(OverhaulingType);
        }
    }
}
