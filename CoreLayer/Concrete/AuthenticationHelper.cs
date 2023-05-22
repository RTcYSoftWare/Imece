using CoreLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Concrete
{
    public class AuthenticationHelper : IAuthenticationHelper
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthenticationHelper(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public string CreateToken(string guid, int id)
        {
            string token = "";

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
            //    issuer: _configuration["Jwt:Issuer"],
            //    audience: _configuration["Jwt:Audience"],
            //    expires: DateTime.Now.AddYears(9),
            //    notBefore: DateTime.Now,
            //    signingCredentials: signingCredentials
            //    );

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("guid",guid),
                    new Claim("id", id.ToString())
                }),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"],
                Expires = DateTime.Now.AddYears(9),
                NotBefore = DateTime.Now,
                SigningCredentials = signingCredentials
            };

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            var tok2 = jwtSecurityTokenHandler.CreateToken(tokenDescription);

            token = jwtSecurityTokenHandler.WriteToken(tok2);

            return token;
        }

        public CurrentUserModel GetCurrentWasher()
        {
            CurrentUserModel currentUserModel = new CurrentUserModel();

            var identity = _httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                currentUserModel.Guid = identity.FindFirst("guid").Value;
                currentUserModel.Id = int.Parse(identity.FindFirst("id").Value ?? "0");
            }

            return currentUserModel;
        }
    }
}
