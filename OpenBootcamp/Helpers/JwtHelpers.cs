using Microsoft.IdentityModel.Tokens;
using OpenBootcamp.Models.DataModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace OpenBootcamp.Helpers
{
    public static class JwtHelpers
    {
        //https://www.c-sharpcorner.com/article/jwt-token-authentication-and-authorizations-in-net-core-6-0-web-api/
        public static IEnumerable<Claim> GetClaims(this UserTokens userAccounts, out Guid Id)
        {
            Id = Guid.NewGuid();
            return GetClaims(userAccounts, Id);
        }
        public static IEnumerable<Claim> GetClaims(this UserTokens userAccounts, Guid Id)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim("Id",userAccounts.Id.ToString()),
                new Claim(ClaimTypes.Name,userAccounts.UserName),
                new Claim(ClaimTypes.Email,userAccounts.EmailId),
                new Claim(ClaimTypes.NameIdentifier,userAccounts.Id.ToString()),
                new Claim(ClaimTypes.Expiration, DateTime.UtcNow.AddDays(1).ToString("MMM ddd dd yyyy HH:mm:ss tt"))

            };

            if (userAccounts.UserName == "Admin")
                claims.Add(new Claim(ClaimTypes.Role, "Administrador"));
            else if (userAccounts.UserName == "User1")
            {
                claims.Add(new Claim(ClaimTypes.Role, "User"));
                claims.Add(new Claim("UserOnly", "User1"));
            }

            return claims;
        }
        public static UserTokens GenTokenKey(UserTokens model, JwtSettings jwtSettings)
        {
            try
            {
                var userToken = new UserTokens();
                if (model == null)
                    throw new ArgumentNullException(nameof(model));

                //Obtain Secret Key
                var key = System.Text.Encoding.ASCII.GetBytes(jwtSettings.IssuerSigningKey);
                Guid Id = Guid.Empty;

                //Expires in 1 Day
                DateTime expireTime = DateTime.UtcNow.AddDays(1);

                // Validity of our token
                userToken.Validity = expireTime.TimeOfDay;

                // Generate Our JWT
                var jwToken = new JwtSecurityToken(
                    issuer: jwtSettings.ValidIssuer,
                    audience: jwtSettings.ValidAudience,
                    claims: GetClaims(model, out Id),
                    notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                    expires: new DateTimeOffset(expireTime).DateTime,
                    signingCredentials: new SigningCredentials
                    (new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256));

                userToken.Token = new JwtSecurityTokenHandler().WriteToken(jwToken);
                userToken.UserName = model.UserName;
                userToken.Id = model.Id;
                userToken.GuidId = Id;

                return userToken;
            }
            catch (Exception ex)
            {
                throw new Exception("Error Generating the JWT", ex); ;
            }
        }
    }
}
