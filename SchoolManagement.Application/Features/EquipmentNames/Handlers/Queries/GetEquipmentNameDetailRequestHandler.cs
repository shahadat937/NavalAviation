using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.EquipmentName;
using SchoolManagement.Application.Features.EquipmentNames.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.EquipmentNames.Handlers.Queries
{
    public class GetEquipmentNameDetailRequestHandler : IRequestHandler<GetEquipmentNameDetailRequest, EquipmentNameDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<EquipmentName> _EquipmentNameRepository;
        public GetEquipmentNameDetailRequestHandler(ISchoolManagementRepository<EquipmentName> EquipmentNameRepository, IMapper mapper)
        {
            _EquipmentNameRepository = EquipmentNameRepository;
            _mapper = mapper;
        }
        public async Task<EquipmentNameDto> Handle(GetEquipmentNameDetailRequest request, CancellationToken cancellationToken)
        {
            var EquipmentName = await _EquipmentNameRepository.Get(request.EquipmentNameId);
            return _mapper.Map<EquipmentNameDto>(EquipmentName);
        }
    }
}
