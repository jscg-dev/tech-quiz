using App.Domain.Context;
using App.Domain.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System;
using System.Text;

namespace App.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly UContext _db;
        private readonly IConfiguration _config;

        public IdentityController(UContext db, IConfiguration config)
        {
            _db = db;
            _config = config;
        }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] User user)
        {
            User? count = await _db.Set<User>().Where(db => db.Username.ToLower() == user.Username.ToLower()).FirstOrDefaultAsync();

            if (count == null) return NotFound();
            if (count.Password != user.Password) return BadRequest("contraseña incorrecta");

            ClaimsIdentity payload = new
            (
                new Claim[]
                {
                    new("jti", Guid.NewGuid().ToString())
                }
            );

            SecurityTokenDescriptor desc = new()
            {
                Subject = payload,
                Issuer = _config.GetSection("AppSettings:jwt:ValidIssuer").Value!,
                Audience = _config.GetSection("AppSettings:jwt:ValidAudience").Value!,
                SigningCredentials = new
                (
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:jwt:IssuerSigningKey").Value!)),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };

            desc
                .Expires = DateTime.UtcNow.AddMinutes(60);

            JwtSecurityTokenHandler handler = new();
            SecurityToken token = handler.CreateToken(desc);
            return Ok($"{JwtBearerDefaults.AuthenticationScheme} {handler.WriteToken(token)}");
        }
    }
}
