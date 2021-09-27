using BasicCRUD.Business.Abstract;
using BasicCRUD.Core.Utilities.Results;
using BasicCRUD.Core.Utilities.Security;
using BasicCRUD.Core.Utilities.Security.Encyption;
using BasicCRUD.Core.Utilities.Security.JWT;
using BasicCRUD.Entities.Concrete.Dtos;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using BasicCRUD.Entities.Concrete.DataModels;

namespace BasicCRUD.Business.Concrete
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private AccessToken CreateAccessToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenOptions = _configuration.GetSection("TokenOptions").Get<TokenOptions>();
            var key = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey);
            var expires = DateTime.Now.AddMinutes(tokenOptions.AccessTokenExpiration);
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken(
                      issuer: tokenOptions.Issuer,
                      audience: tokenOptions.Audience,
                      expires: expires,
                      notBefore: DateTime.Now,
                      claims: SetClaims(user),
                      signingCredentials: signingCredentials
                  );
            var tokenStr = tokenHandler.WriteToken(token);
            return new AccessToken {Expiration= expires,Token=tokenStr };
        }
        private IEnumerable<Claim> SetClaims(User user)
        {
            var claims = new List<Claim>() {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name,user.UserName)
            };
            return claims;

        }
        public Response<AccessToken> GetToken(UserLoginDto userDto)
        {
            var currentUser = new User {Id=552, UserName="frtlec",Password="123",Email="frtlec@hotmail.com",Age=26};
            if (currentUser.UserName== userDto.UserName&& currentUser.Password== userDto.Password)
            {
                return Response<AccessToken>.Success(CreateAccessToken(currentUser), 200);
            }
            return Response<AccessToken>.Fail(new List<string> { "Kullanıcı adı veya şifre yanlış" },401);
        }
    }
}
