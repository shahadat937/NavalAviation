using AutoMapper;
using SchoolManagement.Application.DTOs.EmployeeType;
using SchoolManagement.Application.Features.EmployeeTypes.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;

namespace SchoolManagement.Application.Features.EmployeeTypes.Handlers.Queries
{
    public class GetEmployeeTypeDetailRequestHandler : IRequestHandler<GetEmployeeTypeDetailRequest, EmployeeTypeDto>
    {
        // private readonly IUTOfficerTypeRepository _UTOfficerTypeRepository;
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.EmployeeType> _EmployeeTypeRepository;
        public GetEmployeeTypeDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.EmployeeType> EmployeeTypeRepository, IMapper mapper)
        {
            _EmployeeTypeRepository = EmployeeTypeRepository;
            _mapper = mapper;
        }
        public async Task<EmployeeTypeDto> Handle(GetEmployeeTypeDetailRequest request, CancellationToken cancellationToken)
        {
            var EmployeeType = await _EmployeeTypeRepository.Get(request.EmployeeTypeId);
            return _mapper.Map<EmployeeTypeDto>(EmployeeType);
        }
    }
}
