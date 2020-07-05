using Microsoft.AspNetCore.Identity;
using Safcsp.Restaurant.Application.Dtos;
using Safcsp.Restaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safcsp.Restaurant.Application.Interfaces
{
    public interface IAuthService
    {
        Task<IdentityResult> CreateUser(UserSignUp dto);
        User CheckUser(UserSignIn dto);
        Task<bool> CheckUserPassword(User user, UserSignIn dto);

        Task<IdentityResult> CreateRole(string name);
        Task<IdentityResult> AssginRoleToUser(UserRole userrole);
        Task<string> GenerateJwtToken(User user);

    }
}
