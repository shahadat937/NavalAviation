using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ToolsLocation;
using SchoolManagement.Application.Features.ToolsLocations.Requests.Queries;

namespace SchoolManagement.Application.Features.ToolsLocations.Handlers.Queries
{
    public class GetToolsLocationDetailRequestHandler : IRequestHandler<GetToolsLocationDetailRequest, ToolsLocationDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.ToolsLocation> _ToolsLocationRepository;
        public GetToolsLocationDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.ToolsLocation> ToolsLocationRepository, IMapper mapper)
        {
            _ToolsLocationRepository = ToolsLocationRepository;
            _mapper = mapper;
        }
        public async Task<ToolsLocationDto> Handle(GetToolsLocationDetailRequest request, CancellationToken cancellationToken)
        {
            var ToolsLocation = await _ToolsLocationRepository.Get(request.ToolsLocationId);
            return _mapper.Map<ToolsLocationDto>(ToolsLocation);
        }
    }
}
