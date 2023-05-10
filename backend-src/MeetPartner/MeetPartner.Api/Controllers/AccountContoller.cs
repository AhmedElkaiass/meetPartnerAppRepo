using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MeetPartner.Api.Data;
using MeetPartner.Api.Dtos;
using MeetPartner.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace MeetPartner.Api.Contollers;
[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly AppDbContext _db;
    public readonly IConfiguration _config;
    public AccountController(AppDbContext db, IConfiguration config)
    {
        _db = db;
        _config = config;
    }
    [HttpPost("Register")]
    public async Task<IActionResult> Register(RegisterDto dto)
    {
        UserActionResult result = new();
        if (!ModelState.IsValid)
        {
            result.ErrorMessage = "invalid . please make sure that all data are correct ";
            return Ok(result);
        }
        User user = new User
        {
            Email = dto.Email,
            FullName = dto.FullName,
            HashPasword = Convert.ToBase64String(Encoding.UTF8.GetBytes(dto.Password)),
            RegionId = dto.RegionId
        };
        _db.Users.Add(user);
        int ar = await _db.SaveChangesAsync();
        if (ar != 0)
        {
            result.IsSuccess = true;
        }
        return Ok(result);
    }
    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        UserActionResult result = new();
        User user = await _db.Users.Where(x => x.Email == dto.Email).SingleOrDefaultAsync();
        if (user == null)
        {
            result.ErrorMessage = "this user is not found";
            result.IsSuccess = false;
        }
        else
        {
            var _hashpassowrd = Convert.ToBase64String(Encoding.UTF8.GetBytes(dto.Password));
            if (_hashpassowrd != user.HashPasword)
            {
                result.ErrorMessage = "invalid password";
                result.IsSuccess = false;
            }
            else
            {
                result.Data = new { accessToken = BuildToken(user) };
            }
        }
        return Ok(result);
    }

    [Authorize]
    [HttpGet("Profile")]
    public IActionResult Profile()
    {
       string id = User.Claims.Where(x=> x.Type == System.Security.Claims.ClaimTypes.NameIdentifier).SingleOrDefault()?.Value;
        User user = _db.Users.Find(Convert.ToInt32(id));
        user.HashPasword = null;
        return Ok(new
        {
            Data = user
        });
    }

    private string BuildToken(User user)
    {
        var userSerialise = System.Text.Json.JsonSerializer.Serialize(user);

        var claims = new[] {
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.UserData, userSerialise)
        };
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MyveryLongCryptoKey"));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

        var token = new JwtSecurityToken("https://localhost:7008",
          "https://localhost:7008",
          claims,
          expires: DateTime.Now.AddMinutes(30),
          signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);

    }
}