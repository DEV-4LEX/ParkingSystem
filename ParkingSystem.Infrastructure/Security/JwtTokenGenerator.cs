using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using ParkingSystem.Domain.Interfaces;

namespace ParkingSystem.Infrastructure.Security
{
    public class JwtTokenGenerator : IJwtService
    {
        private const string SECRET_KEY = "SUPER_CHAVE_SECRETA_123456789_ABCDEF";

        public string GenerateResidentToken(
            Guid userId,
            TimeSpan expiration)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.UTF8.GetBytes(SECRET_KEY);

            var tokenId = Guid.NewGuid().ToString();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("tokenId", tokenId),
                    new Claim("userId", userId.ToString()),
                    new Claim("type", "resident")
                }),

                Expires = DateTime.UtcNow.Add(expiration),

                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public string GenerateGuestToken(
            Guid invitationId,
            TimeSpan expiration)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.UTF8.GetBytes(SECRET_KEY);

            var tokenId = Guid.NewGuid().ToString();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("tokenId", tokenId),
                    new Claim("invitationId", invitationId.ToString()),
                    new Claim("type", "guest")
                }),

                Expires = DateTime.UtcNow.Add(expiration),

                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public bool ValidateToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.UTF8.GetBytes(SECRET_KEY);

            try
            {
                tokenHandler.ValidateToken(
                    token,
                    new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey =
                            new SymmetricSecurityKey(key),

                        ValidateIssuer = false,
                        ValidateAudience = false,

                        ClockSkew = TimeSpan.Zero
                    },
                    out SecurityToken validatedToken);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public Guid? GetUserId(string token)
        {
            var handler = new JwtSecurityTokenHandler();

            var jwt = handler.ReadJwtToken(token);

            var claim = jwt.Claims
                .FirstOrDefault(c => c.Type == "userId");

            if (claim == null)
                return null;

            return Guid.Parse(claim.Value);
        }

        public Guid? GetInvitationId(string token)
        {
            var handler = new JwtSecurityTokenHandler();

            var jwt = handler.ReadJwtToken(token);

            var claim = jwt.Claims
                .FirstOrDefault(c => c.Type == "invitationId");

            if (claim == null)
                return null;

            return Guid.Parse(claim.Value);
        }
    }
}