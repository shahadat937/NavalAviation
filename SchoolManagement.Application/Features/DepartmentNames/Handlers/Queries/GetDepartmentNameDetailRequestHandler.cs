using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.DepartmentName;
using SchoolManagement.Application.Features.DepartmentNames.Requests.Queries;

namespace SchoolManagement.Application.Features.DepartmentNames.Handlers.Queries
{
    public class GetDepartmentNameDetailRequestHandler : IRequestHandler<GetDepartmentNameDetailRequest, DepartmentNameDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.DepartmentName> _DepartmentNameRepository;
        public GetDepartmentNameDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.DepartmentName> DepartmentNameRepository, IMapper mapper)
        {
            _DepartmentNameRepository = DepartmentNameRepository;
            _mapper = mapper;
        }
        public async Task<DepartmentNameDto> Handle(GetDepartmentNameDetailRequest request, CancellationToken cancellationToken)
        {
            var DepartmentName = await _DepartmentNameRepository.Get(request.DepartmentNameId);
            return _mapper.Map<DepartmentNameDto>(DepartmentName);
        }
    }
}
