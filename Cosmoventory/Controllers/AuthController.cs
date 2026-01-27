using Cosmoventory.Data;
using Cosmoventory.DTO;
using Cosmoventory.Enums;
using Cosmoventory.Helpers;
using Cosmoventory.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Cosmoventory.Controllers
{
    [Route("api/Auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly JwtTokenService _jwt;

        public AuthController(AppDbContext db, JwtTokenService jwt)
        {
            _db = db;
            _jwt = jwt;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserRequestDTO request)
        {
            // Check username/email uniqueness
            var exists = await _db.Users.AnyAsync(u =>
                u.Username == request.Username || u.Email == request.Email);

            if (exists)
                return BadRequest("Username or email already exists.");

            var user = new User
            {
                Username = request.Username,
                Email = request.Email,
                PasswordHash = PasswordHashHelper.Hash(request.Password),
                Role = OrganizationRole.staff.ToString(),        // Default role
                IsActive = true
            };

            _db.Users.Add(user);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(Register), new
            {
                user.Id,
                user.Username,
                user.Email,
                user.Role
            });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestDTO request)
        {
            var user = await _db.Users.SingleOrDefaultAsync(u =>
                u.Username == request.Username);

            if (user == null)
                return Unauthorized("Invalid credentials.");

            if (!user.IsActive || user.IsLocked)
                return Unauthorized("Account is disabled.");

            if (!PasswordHashHelper.Verify(user.PasswordHash, request.Password))
                return Unauthorized("Invalid credentials.");

            user.LastLoginAt = DateTime.UtcNow;
            await _db.SaveChangesAsync();

            var token = _jwt.GenerateToken(user.Id, user.Username, user.Role);

            return Ok(new
            {
                token,
                user = new
                {
                    user.Id,
                    user.Username,
                    user.Email,
                    user.Role
                }
            });
        }
    }

}
