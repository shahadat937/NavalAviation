using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ServiceLifeTypes;
using SchoolManagement.Application.Features.ServiceLifeTypes.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.ServiceLifeTypes.Handlers.Queries
{
    public class GetServiceLifeTypeDetailRequestHandler : IRequestHandler<GetServiceLifeTypeDetailRequest, ServiceLifeTypeDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<ServiceLifeType> _ServiceLifeTypeRepository;
        public GetServiceLifeTypeDetailRequestHandler(ISchoolManagementRepository<ServiceLifeType> ServiceLifeTypeRepository, IMapper mapper)
        {
            _ServiceLifeTypeRepository = ServiceLifeTypeRepository;
            _mapper = mapper;
        }
        public async Task<ServiceLifeTypeDto> Handle(GetServiceLifeTypeDetailRequest request, CancellationToken cancellationToken)
        {
            var ServiceLifeType = await _ServiceLifeTypeRepository.Get(request.ServiceLifeTypeId);
            return _mapper.Map<ServiceLifeTypeDto>(ServiceLifeType);
        }
    }
}
