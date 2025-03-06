﻿using GalaxyApp.Data.Entities.Identity;
using GalaxyApp.Service.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GalaxyApp.Service.Implement
{
    public class AuthenticationServices : IAuthenticationServices
    {
        private readonly IConfiguration _configuration;

        public AuthenticationServices(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        public async Task<string> GetJWTTokenAsync(AppUser user, UserManager<AppUser> _userManager)
        {



            var AuthClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.GivenName,user.FirstName+user.LastName)
            };

            var UserRoles = await _userManager.GetRolesAsync(user);

            foreach (var vRole in UserRoles)
            {
                AuthClaims.Add(new Claim(ClaimTypes.Role, vRole));
            }

            var AuthKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));

            var Token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddDays(double.Parse(_configuration["JWT:DurationInDays"])),
                claims: AuthClaims,
                signingCredentials: new SigningCredentials(AuthKey, SecurityAlgorithms.HmacSha256Signature)
                );

            return new JwtSecurityTokenHandler().WriteToken(Token);

        }
    }
}
