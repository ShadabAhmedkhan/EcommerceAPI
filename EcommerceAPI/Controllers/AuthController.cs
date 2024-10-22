using EcommerceAPI.Converter;
using EcommerceAPI.DTO;
using EcommerceAPI.Model;
using EcommerceAPI.Repository;
using EcommerceAPI.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EcommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUser<User> _userRepository;
        private readonly IConfiguration _configuration;

        public AuthController(IUser<User> userRepository, IConfiguration configuration)
        {
            _configuration = configuration;
            _userRepository = userRepository;

        }

        // Signup API
        [HttpPost("signup")]
        public IActionResult Signup(LoginDTO user)
        {
            // Add user to the list (or DB in a real application)
            _userRepository.Add(UserConverter.User(user));
            return Ok("User registered successfully");
        }

        // Login API
        [HttpPost("login")]
        public IActionResult Login(LoginDTO loginUser)
        {
            //var user = Users.SingleOrDefault(u => u.Username == loginUser.Username && u.Password == loginUser.Password);
            var user = _userRepository.Login(loginUser);
            if (user == null)
            {
                return Unauthorized("Invalid credentials");
            }

            // Generate JWT Token
            var token = GenerateJwtToken(UserConverter.User(loginUser)); 
            return Ok(new { token , succsess = "Login successfully"});

        }

        private string GenerateJwtToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, user.Username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Issuer"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
