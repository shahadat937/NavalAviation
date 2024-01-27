using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ToolsBoxNames;
using SchoolManagement.Application.Features.ToolsBoxNames.Requests.Queries;

namespace SchoolManagement.Application.Features.ToolsBoxNames.Handlers.Queries
{
    public class GetToolsBoxNameDetailRequestHandler : IRequestHandler<GetToolsBoxNameDetailRequest, ToolsBoxNameDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.ToolsBoxName> _ToolsBoxNameRepository;
        public GetToolsBoxNameDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.ToolsBoxName> ToolsBoxNameRepository, IMapper mapper)
        {
            _ToolsBoxNameRepository = ToolsBoxNameRepository;
            _mapper = mapper;
        }
        public async Task<ToolsBoxNameDto> Handle(GetToolsBoxNameDetailRequest request, CancellationToken cancellationToken)
        {
            var ToolsBoxName = await _ToolsBoxNameRepository.Get(request.ToolsBoxNameId);
            return _mapper.Map<ToolsBoxNameDto>(ToolsBoxName);
        }
    }
}
