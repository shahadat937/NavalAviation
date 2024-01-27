using SchoolManagement.Application.DTOs.Role;
using SchoolManagement.Application.Responses;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Contracts.Identity
{
    public interface IRoleService
    {
        Task<BaseCommandResponse> Save(string roleId, CreateRoleDto model);
        Task<List<SelectedModel>> GetSelectedRoleList();
    }
}
