using SchoolManagement.Application.Constants;
using SchoolManagement.Application.Contracts.Identity;
using SchoolManagement.Application.Models.Identity;
using SchoolManagement.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using SchoolManagement.Application.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace SchoolManagement.Identity.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly JwtSettings _jwtSettings;

        public AuthService(RoleManager<IdentityRole> roleManager,UserManager<ApplicationUser> userManager,
            IOptions<JwtSettings> jwtSettings,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtSettings = jwtSettings.Value;
            _signInManager = signInManager;
        }

        public async Task<AuthResponse> Login(AuthRequest request)
        {


            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == request.Email || x.UserName == request.Email);
            if (user == null)
            {

              throw new NotFoundException("User", request.Email);
            }

            if (await _userManager.IsLockedOutAsync(user))
            {
              var lockoutEnd = await _userManager.GetLockoutEndDateAsync(user);
              var remainingTime = lockoutEnd.HasValue ? (lockoutEnd.Value.UtcDateTime - DateTime.UtcNow).Minutes : 0;
              throw new BadRequestException($"Too many failed attempts. Your account is locked for {remainingTime + 1} more minutes.");
            }

            var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, lockoutOnFailure: true);

            if (!result.Succeeded)
            {
              if (await _userManager.IsLockedOutAsync(user))
              {
                var lockoutEnd = await _userManager.GetLockoutEndDateAsync(user);
                var remainingTime = lockoutEnd.HasValue ? (lockoutEnd.Value.UtcDateTime - DateTime.UtcNow).Minutes : 0;
                throw new BadRequestException($"Too many failed attempts. Your account is locked for {remainingTime + 1} minutes.");
              }

              int failedAttempts = await _userManager.GetAccessFailedCountAsync(user);
              int remainingAttempts = 3 - failedAttempts;
              throw new BadRequestException($"Invalid credentials. {remainingAttempts} attempt(s) left before lockout.");
            }

      JwtSecurityToken jwtSecurityToken = await GenerateToken(user);

            AuthResponse response = new AuthResponse
            {
                Id = user.Id,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Email = user.Email,
                Username = user.UserName,
                Role = user.RoleName,
                BranchId = user.BranchId,
                TraineeId = user.TraineeId
            };

            return response;
        }

        public async Task<RegistrationResponse> Register(RegistrationRequest request)
        {
            var existingUser = await _userManager.FindByNameAsync(request.UserName);

            if (existingUser != null)
            {
                throw new BadRequestException($"Username '{request.UserName}' already exists.");
            }

            var user = new ApplicationUser
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                EmailConfirmed = true
            };

            var existingEmail = await _userManager.FindByEmailAsync(request.Email);

            if (existingEmail == null)
            {
                var result = await _userManager.CreateAsync(user, request.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Admin");
                    return new RegistrationResponse() { UserId = user.Id };
                }
                else
                {
                    throw new BadRequestException($"{result.Errors}");
                }
            }
            else
            {
                throw new BadRequestException($"Email {request.Email } already exists.");
            }
        }

        private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
         
             var rolelist = _roleManager.Roles.Where(r => roles.Contains(r.Name)).Select(x =>x.Id).ToList();
             string roleid = rolelist[0].ToString();

            var roleClaims = new List<Claim>();

            for (int i = 0; i < roles.Count; i++)
            {
                roleClaims.Add(new Claim(ClaimTypes.Role, roles[i]));
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(CustomClaimTypes.Uid, user.Id),
                new Claim(CustomClaimTypes.Rid, roleid)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signingCredentials);
            return jwtSecurityToken;
        }
    }
}
