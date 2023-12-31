﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Features.Accounts.Queries.GetAccountWithEmailAndPassword;
using Application.Interfaces.Repositories;
using Azure.Core;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Persistence.Contexts;
using Persistence.Repositories;

namespace OnlyFoodApp.Controllers
{

    [Route("api/v1/auth/login")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public TokenController(IConfiguration config, ApplicationDbContext context, IUnitOfWork unitOfWork)
        {
            _configuration = config;
            _context = context;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post(GetAccountWithEmailAndPasswordDto _userData)
        {
            if (_userData != null && _userData.Email != null && _userData.Password != null)
            {
                var user = await GetUser(_userData.Email, _userData.Password);
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

                    var chef = _unitOfWork.Repository<Chef>().Entities.Where(a => a.AccountId.Equals(user.Id)).SingleOrDefault();
                    if (chef != null)
                    {
                        var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        //new Claim("Roles", role),
                        new Claim(ClaimTypes.Role, role),
                        new Claim("Id", user.Id.ToString()),
                        new Claim("LastName", user.LastName),
                        new Claim("UserName", user.Username),
                        new Claim("Email", user.Email),
                        new Claim("ChefId", chef.Id.ToString()),
                        new Claim("Role", role)
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
                        var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        //new Claim("Roles", role),
                        new Claim(ClaimTypes.Role, role),
                        new Claim("Id", user.Id.ToString()),
                        new Claim("LastName", user.LastName),
                        new Claim("UserName", user.Username),
                        new Claim("Email", user.Email),
                        new Claim("Role", role)
                    };

                        //create claims details based on the user information

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
            return await _context.Accounts.Include(c => c.Chef).FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        }


    }
}

