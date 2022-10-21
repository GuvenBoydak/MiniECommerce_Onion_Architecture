using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MiniECommerce.Application;
using MiniECommerce.Domain;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MiniECommerce.Infrastructure
{
    public class TokenHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; }

        private TokenOption _tokenOption;

        private DateTime _accessTokenExpiration;

        public TokenHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOption = Configuration.GetSection("TokenOptions").Get<TokenOption>();
        }

        public AccessToken CreateToken(AppUser appUser, List<Role> roles)
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOption.AccessTokenExpiration);

            SecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenOption.SecurityKey));

            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);

            JwtSecurityToken jwt = CreateJwtSecurityToken(_tokenOption, appUser, signingCredentials, roles);

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            string token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken { Token = token, Expiration = _accessTokenExpiration };
        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOption tokenOptions, AppUser appUser, SigningCredentials signingCredentials, List<Role> roles)
        {
            JwtSecurityToken jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now, 
                claims: SetClaims(appUser, roles),
                signingCredentials: signingCredentials
                );
            return jwt;
        }

        private IEnumerable<Claim> SetClaims(AppUser appUser, List<Role> roles)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,appUser.ID.ToString()),
                new Claim(ClaimTypes.Name, appUser.UserName),
                new Claim("AppUserId",appUser.ID.ToString())
            };

            foreach (Role item in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, item.Name));
            }
            return claims;
        }
    }
}
