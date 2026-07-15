using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MicroservicesJwtApi.Models;

namespace MicroservicesJwtApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _configuration;

    private static readonly List<User> Users =
    [
        new User
        {
            Username = "admin",
            Password = "Admin@123",
            Role = "Admin"
        },
        new User
        {
            Username = "user",
            Password = "User@123",
            Role = "User"
        }
    ];

    public AuthController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginModel model)
    {
        var user = Users.FirstOrDefault(user =>
            user.Username == model.Username &&
            user.Password == model.Password);

        if (user == null)
        {
            return Unauthorized(new
            {
                Message = "Invalid username or password."
            });
        }

        var token = GenerateJwtToken(user);

        return Ok(new
        {
            Token = token,
            Role = user.Role
        });
    }

    private string GenerateJwtToken(User user)
    {
        var jwtKey = _configuration["Jwt:Key"]
            ?? throw new InvalidOperationException(
                "JWT key is not configured.");

        var jwtIssuer = _configuration["Jwt:Issuer"];
        var jwtAudience = _configuration["Jwt:Audience"];

        var durationInMinutes =
            _configuration.GetValue<int>(
                "Jwt:DurationInMinutes");

        var claims = new[]
        {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Role, user.Role)
        };

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(jwtKey));

        var credentials = new SigningCredentials(
            key,
            SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: jwtIssuer,
            audience: jwtAudience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(
                durationInMinutes),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler()
            .WriteToken(token);
    }
}