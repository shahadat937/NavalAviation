using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.AirCraftName;
using SchoolManagement.Application.Features.AirCraftNames.Requests.Queries;

namespace SchoolManagement.Application.Features.AirCraftNames.Handlers.Queries
{
    public class GetAirCraftNameDetailRequestHandler : IRequestHandler<GetAirCraftNameDetailRequest, AirCraftNameDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.AirCraftName> _AirCraftNameRepository;
        public GetAirCraftNameDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.AirCraftName> AirCraftNameRepository, IMapper mapper)
        {
            _AirCraftNameRepository = AirCraftNameRepository;
            _mapper = mapper;
        }
        public async Task<AirCraftNameDto> Handle(GetAirCraftNameDetailRequest request, CancellationToken cancellationToken)
        {
            var AirCraftName = await _AirCraftNameRepository.FindOneAsync(x => x.AirCraftNameId == request.AirCraftNameId, "DepartmentName");
            return _mapper.Map<AirCraftNameDto>(AirCraftName);
        }
    }
}
