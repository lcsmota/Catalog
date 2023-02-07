using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CleanArchApi.Domain.Auth;
using CleanArchApi.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CleanArchApi.WebApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[Produces("application/json")]
public class AuthController : ControllerBase
{
    private readonly IAuthenticate _auth;
    private readonly IConfiguration _config;
    public AuthController(IAuthenticate auth, IConfiguration config)
    {
        _auth = auth;
        _config = config;
    }

    [HttpPost("RegisterUser")]
    [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
    public async Task<ActionResult> RegisterUser(RegisterUser userInfo)
    {
        var result = await _auth.RegisterUserAsync(userInfo.Email, userInfo.Password);

        return result
            ? Ok("User was registered successfully.")
            : BadRequest("Invalid login");
    }

    [HttpPost("LoginUser")]
    [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
    public async Task<ActionResult> LoginUser(LoginUser userInfo)
    {
        var result = await _auth.AuthenticateAsync(userInfo.Email, userInfo.Password);

        return result
            ? Ok(GenerateToken(userInfo))
            : BadRequest("Invalid login");
    }

    private UserToken GenerateToken(LoginUser userInfo)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.Email, userInfo.Email),
            new Claim("Clean Architecture", "API")
        };

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_config.GetSection("Jwt:Key").Value));

        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var expiration = DateTime.UtcNow.AddMinutes(30);

        JwtSecurityToken token = new JwtSecurityToken(
            issuer: _config.GetSection("Jwt:Issuer").Value,
            audience: _config.GetSection("Jwt:Audience").Value,
            claims: claims,
            expires: expiration,
            signingCredentials: credentials
        );

        return new UserToken
        {
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            Expiration = expiration
        };
    }
}
