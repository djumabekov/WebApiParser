using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiParser.ReferenceParser.DTOs;
using WebApiParser.ReferenceParser.Options;

namespace WebApiParser.Infrastructure.Services
{
    public class HttpContextService : IContextService
    {
        private readonly IOptions<JwtOptions> _options;
        public UserModel? CurrentUser { get; set; } = null;
        public HttpContextService(IOptions<JwtOptions> options)
        {
            _options = options;
        }

        public Guid? ValidateToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_options.Value.Key);
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = Guid.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);
                var mail = jwtToken.Claims.First(x => x.Type == "mail").Value;

                return userId;
            }
            catch
            {
                return null;
            }
        }
    }

    public interface IContextService
    {
        public UserModel? CurrentUser { get; set; }
        public Guid? ValidateToken(string token);
    }

}
