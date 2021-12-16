using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace Api.Controllers.Authorize
{
    /// <summary>
    /// Содержит операции с токеном.
    /// </summary>
    public class TokenOperations
    {
        public string CreateToken(string login)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, login),
            };
            
            ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
            
            var now = DateTime.UtcNow;

            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                notBefore: now,
                claims: claimsIdentity.Claims,
                expires: now.Add(TimeSpan.FromDays(AuthOptions.LIFETIME)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            
            return encodedJwt;
        }

        public string CheckToken(string token)
        {
            var decodedJwt = new JwtSecurityTokenHandler().ReadJwtToken(token);
            var decodedLogin = decodedJwt.Claims.First().Value;
            var decodedEndDate = decodedJwt.ValidTo;

            if (decodedEndDate > DateTime.Now)
                return decodedLogin;

            throw new Exception("Токен не действителен.");
        }
    }
}