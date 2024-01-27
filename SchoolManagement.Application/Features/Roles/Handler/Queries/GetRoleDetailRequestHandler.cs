using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Role;
using SchoolManagement.Application.Features.Roles.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.Roles.Handler.Queries
{
    public class GetRoleDetailRequestHandler : IRequestHandler<GetRoleDetailRequest, RoleDto>
    {
        private readonly IMapper _mapper; 
        private readonly ISchoolManagementRepository<Role> _branchRepository; 
        public GetRoleDetailRequestHandler(ISchoolManagementRepository<Role> branchRepository, IMapper mapper)
        {
            _branchRepository = branchRepository; 
            _mapper = mapper;
        }
        public async Task<RoleDto> Handle(GetRoleDetailRequest request, CancellationToken cancellationToken)
        {
            var branch = await _branchRepository.Get(request.RoleId);
            return _mapper.Map<RoleDto>(branch);
        }
    }
}
