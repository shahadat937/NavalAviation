using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ToolsTypes;
using SchoolManagement.Application.Features.ToolsTypes.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.ToolsTypes.Handlers.Queries
{
    public class GetToolsTypeDetailRequestHandler : IRequestHandler<GetToolsTypeDetailRequest, ToolsTypeDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<ToolsType> _ToolsTypeRepository;
        public GetToolsTypeDetailRequestHandler(ISchoolManagementRepository<ToolsType> ToolsTypeRepository, IMapper mapper)
        {
            _ToolsTypeRepository = ToolsTypeRepository;
            _mapper = mapper;
        }
        public async Task<ToolsTypeDto> Handle(GetToolsTypeDetailRequest request, CancellationToken cancellationToken)
        {
            var ToolsType = await _ToolsTypeRepository.Get(request.ToolsTypeId);
            return _mapper.Map<ToolsTypeDto>(ToolsType);
        }
    }
}
