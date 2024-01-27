using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.AirCraftFlying;
using SchoolManagement.Application.Features.AirCraftFlyings.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.AirCraftFlyings.Handlers.Queries
{
    public class GetAirCraftFlyingDetailRequestHandler : IRequestHandler<GetAirCraftFlyingDetailRequest, AirCraftFlyingDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<AirCraftFlying> _AirCraftFlyingRepository;
        public GetAirCraftFlyingDetailRequestHandler(ISchoolManagementRepository<AirCraftFlying> AirCraftFlyingRepository, IMapper mapper)
        {
            _AirCraftFlyingRepository = AirCraftFlyingRepository;
            _mapper = mapper;
        }
        public async Task<AirCraftFlyingDto> Handle(GetAirCraftFlyingDetailRequest request, CancellationToken cancellationToken)
        {
            var AirCraftFlying = await _AirCraftFlyingRepository.Get(request.AirCraftFlyingId);
            return _mapper.Map<AirCraftFlyingDto>(AirCraftFlying);
        }
    }
}
