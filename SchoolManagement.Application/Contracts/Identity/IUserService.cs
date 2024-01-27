using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.User;
using SchoolManagement.Application.DTOs.UserTransferBackups;
using SchoolManagement.Application.Models;
using SchoolManagement.Application.Models.Identity;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Contracts.Identity
{
    public interface IUserService
    { 
      Task<BaseCommandResponse> UpdateUserPassword(string userId, PasswordChangeDto userDto);
      Task<PagedResult<UserDto>> GetUsers(QueryParams queryParams);
      Task<List<UserTransferBackupDto>> GetAllUsersInformation();
      Task<UserDto> GetUserById(string id);
      Task<BaseCommandResponse> Save(string userId, CreateUserDto user);
      Task<BaseCommandResponse> DeleteUser(string id);

    //Task<PagedResult<UserDto>> GetStudentUsers(QueryParams queryParams);
    //Task<PagedResult<UserDto>> GetTeacherUsers(QueryParams queryParams);
    //Task<List<Employee>> GetEmployees();
    //Task<Employee> GetEmployee(string userId);

    //Task<PagedResult<UserDto>> GetUsers(QueryParams queryParams);
    //Task<UserDto> GetUserById(string id);
    //Task<BaseCommandResponse> Save(string userId, CreateUserDto user);
    //Task<BaseCommandResponse> DeleteUser(string id);

  }
}
