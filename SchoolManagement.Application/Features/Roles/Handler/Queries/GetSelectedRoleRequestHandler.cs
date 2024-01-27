using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.Roles.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.Roles.Handlers.Queries
{
    public class GetSelectedRoleRequestHandler : IRequestHandler<GetSelectedRoleRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<Role> _RoleRepository;


        public GetSelectedRoleRequestHandler(ISchoolManagementRepository<Role> RoleRepository)
        {
            _RoleRepository = RoleRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedRoleRequest request, CancellationToken cancellationToken)
        {
            ICollection<Role> codeValues = await _RoleRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.RoleName,
                Value = x.RoleId
            }).ToList();
            return selectModels;
        }
    }
}
