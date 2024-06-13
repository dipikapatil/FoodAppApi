using FoodAppApi.Models;
using FoodAppApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FoodAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    { 
        private readonly ILoginService loginService;
        private readonly IConfiguration _configuration;
        private readonly IConfigurationSection _jwtSettings;
        public LoginController(ILoginService customerService,IConfiguration configuration)
        {
            this.loginService = customerService;
            _configuration = configuration;
            _jwtSettings = _configuration.GetSection("JwtSettings");
        }
        //[HttpPost("login")]
        //public IActionResult Login([FromBody] User user)
        //{
        //    if (user is null)
        //    {
        //        return BadRequest("Invalid Client Request");
        //    }
        //    if (user.UserName =="dipika" && user.Passwsord == "dip@123")
        //    {
        //        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@123"));
        //        var siginCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
        //        var tokenOptions = new JwtSecurityToken(
        //            issuer: "",
        //            audience: "",
        //            claims: new List<Claim>(),
        //            expires :DateTime.Now.AddMinutes(5),
        //            signingCredentials: siginCredentials
        //            );
        //        var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        //        return Ok(new AuthenticatedResponse { Token = tokenString });
        //    }
        //    return Unauthorized();

        //}
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(User loginRequest)
        {
            if (loginRequest == null || string.IsNullOrEmpty(loginRequest.UserName) || string.IsNullOrEmpty(loginRequest.Passwsord))
            {
                return BadRequest("Missing login details");
            }

            var loginResponse = await loginService.Login(loginRequest);

            if (loginResponse == null)
            {
                return Unauthorized(new AuthenticatedResponse {ErrorMessage="Inavlid credentials" });
            }

            return Ok(loginResponse);
        }
    }
}
