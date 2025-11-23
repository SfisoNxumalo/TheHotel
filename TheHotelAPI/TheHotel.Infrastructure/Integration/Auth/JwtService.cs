using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TheHotel.Domain.DomainExceptions;
using TheHotel.Domain.DTOs.UserDTO;
using TheHotel.Domain.Interfaces.Integrations;

namespace TheHotel.Infrastructure.Integration.Auth
{
    public class JwtService : ITokenService
    {

        private readonly IConfiguration _configuration;
        private readonly SymmetricSecurityKey _key;

        public JwtService(IConfiguration configurations)
        {
            _configuration = configurations;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtConfig:AccessTokenSecret"]!));
        }

        public string GenerateAccessToken(UserDetailsDTO userLoginDetails)
        {
            try
            {
                if (string.IsNullOrEmpty(userLoginDetails.Id.ToString()))
                {
                    throw new ServiceException("User uid is required");
                }

                var claims = new List<Claim>
                {
                    new(JwtRegisteredClaimNames.Sub, userLoginDetails.Id.ToString()),
                    new(JwtRegisteredClaimNames.Email, userLoginDetails.Email),
                    new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                var Issuer = _configuration["JwtConfig:Issuer"];
                var Audience = _configuration["JwtConfig:Audience"];

                var tokenValidityMins = int.Parse(_configuration["JwtConfig:TokenValidityMins"]!);
                var tokenExpiryTimestamp = DateTime.UtcNow.AddMinutes(tokenValidityMins);

                var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = tokenExpiryTimestamp,
                    SigningCredentials = creds,
                    Issuer = Issuer,
                    Audience = Audience
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);

                return tokenHandler.WriteToken(token);
            }
            catch
            {
                throw new ServiceException("An error occurred while trying to generate a token");
            }

        }

        public string GenerateRefreshToken(Guid userId)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["JwtConfig:RefreshTokenSecret"])
            );

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["JwtConfig:Issuer"],
                audience: _configuration["JwtConfig:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddDays(7),    // long expiry
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public ClaimsPrincipal? ValidateRefreshToken(string refreshToken)
        {
            if (string.IsNullOrWhiteSpace(refreshToken))
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.UTF8.GetBytes(_configuration["JwtConfig:RefreshTokenSecret"]!);

            try
            {
                var principal = tokenHandler.ValidateToken(
                    refreshToken,
                    new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = true,
                        ValidIssuer = _configuration["JwtConfig:Issuer"],
                        ValidateAudience = true,
                        ValidAudience = _configuration["JwtConfig:Audience"],
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero
                    },
                    out SecurityToken validatedToken
                );

                if (validatedToken is JwtSecurityToken jwtToken)
                {
                    var alg = jwtToken.Header.Alg;
                    if (alg != SecurityAlgorithms.HmacSha256 &&
                        alg != SecurityAlgorithms.HmacSha512 &&
                        alg != SecurityAlgorithms.HmacSha384)
                    {
                        return null;
                    }
                }

                return principal;
            }
            catch
            {
                return null;
            }
        }
    }
}
