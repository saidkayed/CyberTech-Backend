
using CyberTech_Backend.Controllers.DTO;
using CyberTech_Backend.Helper;
using CyberTech_Backend.Models;
using CyberTech_Backend.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CyberTech_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IPlayerRepository _playerRepository;
        IConfiguration _configuration;

        public AuthController(IPlayerRepository playerRepository, IConfiguration configuration)
        {
            _playerRepository = playerRepository;
            _configuration = configuration;
        }


        [HttpPost]
        [Route("/Login")]
        public async Task<ActionResult> Login([FromBody] PlayerLoginDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // authenticate the user
            var user = Authenticate(model.Username, model.Password);
            if (user == null)
            {
                return Unauthorized();
            }

            // create the token
            var token = CreateToken(user.Username, user.Email, user.Role);

            // return the token
            return Ok(new { token });
        }

        [HttpPost]
        [Route("/Refresh")]
        public async Task<ActionResult> Refresh([FromBody] string token)
        {
            var newToken = RefreshToken(token);
            return Ok(new { token = newToken });
        }

        private Player Authenticate(string username, string password)
        {
            Player player = _playerRepository.GetPlayerByUsername(username).Result;

            if (player == null)
            {
                return null;
            }

            if (!PasswordHelper.VerifyPassword(password, player.PasswordHash))
            {
                return null;
            }

            return player;
        }


        private string CreateToken(string username, string email, Role role)
        {
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.Email, email),
            new Claim(ClaimTypes.Role, role.ToString())
        };
            var creds = new SigningCredentials(new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value)), SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: "CyberTech-Backend",
                audience: "CyberTech-Client",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private string RefreshToken(string token)
        {
            var principal = new JwtSecurityTokenHandler().ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value)),
                ValidateIssuer = true,
                ValidIssuer = "CyberTech-Backend",
                ValidateAudience = true,
                ValidAudience = "CyberTech-Client",
                ValidateLifetime = false
            }, out SecurityToken validatedToken);

            var newToken = CreateToken(principal.Claims.First(c => c.Type == ClaimTypes.Name).Value,
                principal.Claims.First(c => c.Type == ClaimTypes.Email).Value,
                (Role)Enum.Parse(typeof(Role), principal.Claims.First(c => c.Type == ClaimTypes.Role).Value));
            return newToken;
        }




    }


}

