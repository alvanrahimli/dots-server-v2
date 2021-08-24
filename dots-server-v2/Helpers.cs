using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;
using dots_server_v2.Models;
using Microsoft.IdentityModel.Tokens;

namespace dots_server_v2
{
    public static class Helpers
    {
        public static string GetHash(string str)
        {
            using var sha256Hash = SHA256.Create();
            var bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(str));
            return Convert.ToBase64String(bytes);
        }

        public static string GetJwt(DotsUser user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            
            var secretBytes = Encoding.UTF8.GetBytes("//TODO:_This_is_nice_secret_key");
            var key = new SymmetricSecurityKey(secretBytes);
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expirationDate = DateTime.UtcNow.AddMinutes(2);
            var jwtToken = new JwtSecurityToken(
                expires: expirationDate,
                signingCredentials: cred);

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(jwtToken);
        }
    }
}