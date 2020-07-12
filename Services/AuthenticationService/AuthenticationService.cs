using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Models.UserModel;
using Repository;

namespace Services.AuthenticationService
{
    public class AuthenticationService : IAuthenticationService
    {
        private IUnitOfWork _unitOfWork;
        private IConfiguration _configuration;

        public AuthenticationService(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        public async Task<string> Login(UserForLogin userForLogin)
        {
            try
            {
                var existUser = await _unitOfWork.Authentication.Login(userForLogin);

                if(existUser != null)
                {
                    var tokenDescriptor = new SecurityTokenDescriptor()
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                            new Claim("employeeId", existUser.EmployeeId.ToString())
                        }),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("ApplicationSettings:JWT_Secret"))), SecurityAlgorithms.HmacSha256),
                        Expires = DateTime.Now.AddSeconds(10)
                    };

                    var tokenHandler = new JwtSecurityTokenHandler();
                    var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                    var token = tokenHandler.WriteToken(securityToken);

                    return token;

                }
                return null;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IdentityResult> Register(UserForRegister userForRegister)
        {
            
                var user = new User()
                {
                    UserName = userForRegister.Username,
                    EmployeeId = userForRegister.EmployeeId
                };

                var userToReturn = await _unitOfWork.Authentication.Register(user, userForRegister.Password);
                return userToReturn;
            
           
        }
    }
}
