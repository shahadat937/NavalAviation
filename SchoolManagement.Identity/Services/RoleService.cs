using AutoMapper;
using SchoolManagement.Application.Contracts.Identity;
using SchoolManagement.Identity.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolManagement.Application.Responses;
using SchoolManagement.Application.Exceptions;
using Microsoft.AspNetCore.Http;
using SchoolManagement.Application.Constants;
using SchoolManagement.Application.DTOs.Role;
using SchoolManagement.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace SchoolManagement.Identity.Services
{
    public class RoleService : IRoleService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public RoleService(RoleManager<IdentityRole> roleManager,UserManager<ApplicationUser> userManager, IMapper mapper,IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _mapper = mapper;
            _roleManager = roleManager;
            this._httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<SelectedModel>> GetSelectedRoleList()
        {
            ICollection<IdentityRole> roles =await _roleManager.Roles.ToListAsync();
            //string[] role = {CustomRoleTypes.Employee,CustomRoleTypes.Admin};
            //List<SelectedModel> selectModels = roles.Where(x => !role.Contains(x.Name)).Select(x => new SelectedModel
            List<SelectedModel> selectModels = roles.Select(x => new SelectedModel
            {
                Text = x.Name,
                Value = x.Name
            }).ToList();
            return selectModels;
        }

        public async Task<BaseCommandResponse> Save(string roleId, CreateRoleDto model)
        {
            var response = new BaseCommandResponse();

            if (!String.IsNullOrWhiteSpace(roleId))
            {
                var role = _roleManager.Roles.SingleOrDefault(x => x.Id == roleId);

                if (role == null)
                {
                    throw new BadRequestException("Role not found !");
                }
               
                role.Name = model.RoleName;
                await _roleManager.UpdateAsync(role);
                response.Success = true;
                response.Message = "Updated Successful";
                // response.Id = User.Id;
            }

            else
            {
                var Role = new IdentityRole()
                {
                    Name = model.RoleName,
                    NormalizedName = model.RoleName.ToUpper()
                };
                await _roleManager.CreateAsync(Role);
                response.Success = true;
                response.Message = "Creation Successful";
                // response.Id = User.Id;
            }

            return response;
        }


    }
}
