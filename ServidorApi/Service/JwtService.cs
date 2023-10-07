using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ServidorApi.Service
{
    public class JwtService
    {
        private readonly string _secret;
        private readonly string _expDate;

        public JwtService(string secret, string expDate)
        {
            _secret = secret;
            _expDate = expDate;
        }

        public string GenerateSecurityToken(List<Claim> claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_expDate));

            var token = new JwtSecurityToken(
                expires: expires,
                signingCredentials: creds,
                claims: claims
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
