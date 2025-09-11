using Booking.Application.Common.Interfaces;
using Booking.Domain.Entities;
using Booking.Domain.Enums;
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
namespace Booking.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly SymmetricSecurityKey _key;
        private readonly string _issuer;
        private readonly string _audiance;
        private readonly int _expirationInDays;
        private readonly CookieOptions _cookieOptions;
        private readonly IUnitOfWork _unitOfWork;
        //private readonly ICurrentUserService _currentUser;
        public AuthService(IConfiguration config, IUnitOfWork unitOfWork)
        {
            // JWT Configs
            var signingKey = config["Jwt:SigningKey"];
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey));
            _issuer = config["Jwt:Issuer"];
            _audiance = config["Jwt:Audience"];
            _expirationInDays = int.Parse(config["Jwt:ExpirationInDays"]);

            // Cookie configuration
            _cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.None,
                Expires = DateTime.UtcNow.AddDays(_expirationInDays),
                IsEssential = true
            };
            _unitOfWork = unitOfWork;
        }

        public string CreateToken(User user)
        {
            // Retrieve user roles using RoleManager
            var userRoles = user.Roles;

            // Set claims (the information we want to store in the JWT)
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName)
            };

            // Add each role as a claim
            foreach (var role in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Name));
            }

            // Get the JWT secret key and issuer from configuration
            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);

            // Set expiration for the token
            var expiration = DateTime.UtcNow.AddDays(_expirationInDays);

            // Create the token
            var token = new JwtSecurityToken(
                issuer: _issuer,       // Get issuer from configuration
                audience: _audiance,   // Get audience from configuration
                claims: claims,
                expires: expiration,
                signingCredentials: creds
            );

            // Return the token as a string
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public void SetAccessTokenCookie(HttpContext ctx, string token)
        {
            ctx.Response.Cookies.Append("access_token", token, _cookieOptions);
        }

        public void UnsetAccessTokenCookie(HttpContext ctx)
        {
            ctx.Response.Cookies.Delete("access_token", _cookieOptions);
        }
    }
}
