using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Safcsp.Restaurant.Application.Common;
using Safcsp.Restaurant.Application.Dtos;
using Safcsp.Restaurant.Application.Interfaces;
using Safcsp.Restaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Safcsp.Restaurant.Application.Services
{

    public class AuthService:IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly JwtSettings _jwtSettings;
        public AuthService(UserManager<User> userManager, RoleManager<Role> roleManager, IOptionsSnapshot<JwtSettings> jwtSettings)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtSettings = jwtSettings.Value;

        }

        public async Task<IdentityResult> CreateUser(UserSignUp dto)
        {
            var user = new User()
            {
                FullName = dto.FullName,
                UserName = dto.FullName,
                PhoneNumber = dto.PhoneNumber,
                Email = dto.Email
            };
            return await _userManager.CreateAsync(user, dto.Password);
        }

        public User CheckUser(UserSignIn dto)
        {
            
           return  _userManager.Users.SingleOrDefault(u => u.Email == dto.Email);

        }

        public async Task<bool> CheckUserPassword(User user, UserSignIn dto)
        {
            return await _userManager.CheckPasswordAsync(user, dto.Password);
        }

        public async Task<IdentityResult> CreateRole(string name)
        {
            var newRole = new Role
            {
                Name = name
            };
            return await _roleManager.CreateAsync(newRole);


        }

        public async Task<IdentityResult> AssginRoleToUser(UserRole dto)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.Email == dto.Email);
          
            return await _userManager.AddToRoleAsync(user, dto.RoleName);
            
        }

        public async Task<string> GenerateJwtToken(User user)
        {
            var claims = new List<Claim>
             {
        new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
        new Claim(ClaimTypes.Name, user.UserName),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = roles.Select(r => new Claim(ClaimTypes.Role, r));
            claims.AddRange(roleClaims);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_jwtSettings.ExpirationInDays));

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Issuer,
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }




    }
}
