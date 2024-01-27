using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.RetirementType;
using SchoolManagement.Application.Features.RetirementTypes.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.RetirementTypes.Handlers.Queries
{
    public class GetRetirementTypeDetailRequestHandler : IRequestHandler<GetRetirementTypeDetailRequest, RetirementTypeDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<RetirementType> _RetirementTypeRepository;
        public GetRetirementTypeDetailRequestHandler(ISchoolManagementRepository<RetirementType> RetirementTypeRepository, IMapper mapper)
        {
            _RetirementTypeRepository = RetirementTypeRepository;
            _mapper = mapper;
        }
        public async Task<RetirementTypeDto> Handle(GetRetirementTypeDetailRequest request, CancellationToken cancellationToken)
        {
            var RetirementType = await _RetirementTypeRepository.Get(request.RetirementTypeId);
            return _mapper.Map<RetirementTypeDto>(RetirementType);
        }
    }
}
