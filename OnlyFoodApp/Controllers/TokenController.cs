using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Features.Accounts.Queries.GetAccountWithEmailAndPassword;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Persistence.Contexts;

namespace OnlyFoodApp.Controllers
{

    [Route("api/token/{email}/{password}")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly ApplicationDbContext _context;

        public TokenController(IConfiguration config, ApplicationDbContext context)
        {
            _configuration = config;
            _context = context;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromRoute] string email, [FromRoute] string password)
        {
            if (email != null && password != null)
            {
                var user = await GetUser(email, password);
                var role = "";
                
                if (user != null)
                {
                    if (user.Roles == 2)
                    {
                        role = "Admin";
                    }
                    else if (user.Roles == 1)
                    {
                        role = "Chef";
                    }
                    else if (user.Roles == 0)
                    {
                        role = "Customer";
                    }

                    //create claims details based on the user information
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        //new Claim("Roles", role),
                        new Claim(ClaimTypes.Role, role),
                        new Claim("Id", user.Id.ToString()),
                        new Claim("LastName", user.LastName),
                        new Claim("UserName", user.Username),
                        new Claim("Email", user.Email)
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(60),
                        signingCredentials: signIn);

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }


        private async Task<Account> GetUser(string email, string password)
        {
            return await _context.Accounts.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        }

        //private async Task<IActionResult> GenerateJwtToken(GetAccountWithEmailAndPasswordDto user)
        //{
        //    var account = await GetUser(user.Email, user.Password); // Implement a method to retrieve user roles from your data store

        //    var claims = new List<Claim>
        //    {
        //        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
        //        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        //        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
        //        new Claim(ClaimTypes.Name, user.Password),
        //        new Claim(ClaimTypes.Email, user.Email),
        //    };

        //    // Add user roles to claims
        //    foreach (var role in roles)
        //    {
        //        claims.Add(new Claim(ClaimTypes.Role, role));
        //    }

        //    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        //    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        //    var token = new JwtSecurityToken(
        //        _configuration["Jwt:Issuer"],
        //        _configuration["Jwt:Audience"],
        //        claims,
        //        expires: DateTime.UtcNow.AddMinutes(10),
        //        signingCredentials: credentials
        //    );

        //    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        //}



        //[AllowAnonymous]
        //[HttpPost]
        //public async Task<IActionResult> Login([FromBody] GetAccountWithEmailAndPasswordDto login)
        //{
        //    IActionResult response = Unauthorized();
        //    var user = await AuthenticateUser(login);

        //    if (user != null)
        //    {
        //        var tokenResult = await GenerateJwtToken(user);
        //        return tokenResult;
        //    }

        //    return response;
        //}
    }
}

