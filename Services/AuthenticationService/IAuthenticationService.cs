using Entities;
using Microsoft.AspNetCore.Identity;
using Models.UserModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.AuthenticationService
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> Register(UserForRegister userForRegister);
        Task<string> Login(UserForLogin userForLogin);
    }
}
