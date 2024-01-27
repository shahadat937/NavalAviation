using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.EndLifeTypes;
using SchoolManagement.Application.Features.EndLifeTypes.Requests.Queries;

namespace SchoolManagement.Application.Features.EndLifeTypes.Handlers.Queries
{
    public class GetEndLifeTypeDetailRequestHandler : IRequestHandler<GetEndLifeTypeDetailRequest, EndLifeTypeDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.EndLifeType> _EndLifeTypeRepository;
        public GetEndLifeTypeDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.EndLifeType> EndLifeTypeRepository, IMapper mapper)
        {
            _EndLifeTypeRepository = EndLifeTypeRepository;
            _mapper = mapper;
        }
        public async Task<EndLifeTypeDto> Handle(GetEndLifeTypeDetailRequest request, CancellationToken cancellationToken)
        {
            var EndLifeType = await _EndLifeTypeRepository.Get(request.EndLifeTypeId);
            return _mapper.Map<EndLifeTypeDto>(EndLifeType);
        }
    }
}
