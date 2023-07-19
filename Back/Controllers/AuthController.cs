using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyPawPal.Filters;
using MyPawPal.Services;
using System.Security.Cryptography;
using System.Text;

namespace MyPawPal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly JwtService _jwtService;
        private readonly MyDbContext _dbContext;

        public AuthController(JwtService jwtService, MyDbContext dbContext)
        {
            _jwtService = jwtService;
            _dbContext = dbContext;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        [Authorize]
        public async Task<ActionResult> Login(string email, string passwordHash)
        {
            var user = await _dbContext.UserInfos.SingleOrDefaultAsync(u => u.Email == email);

            if (user == null)
            {
                return Unauthorized();
            }

            var passwordHasher = new PasswordHasher<UserInfo>();
            if (passwordHasher.VerifyHashedPassword(user, user.Password_Hash, passwordHash) != PasswordVerificationResult.Success)
            {
                return Unauthorized();
            }

            // Si le mot de passe est valide, générer le token JWT et le renvoyer dans la réponse HTTP
            var token = _jwtService.GenerateToken(email);
            return Ok(new { token });
        }
    }
}