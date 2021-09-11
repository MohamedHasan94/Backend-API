using FullStackTask.Models;
using FullStackTask.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FullStackTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public object JwtRegisteredClaims { get; private set; }

        public AuthenticationController(UserManager<AppUser> userManager
            , RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }


        /// <summary>
        /// Register a new user
        /// </summary>
        /// <param name="registerModel">Username, email, password</param>
        /// <returns>string</returns>
        /// POST:/api/authentication/register
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel registerModel)
        {
            var user = await _userManager.FindByNameAsync(registerModel.Username);
            if (user != null) return BadRequest("User already exists.");

            AppUser appUser = new AppUser
            {
                Email = registerModel.Email,
                UserName = registerModel.Username,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var result = await _userManager.CreateAsync(appUser, registerModel.Password);
            if (!result.Succeeded) return BadRequest("User creation failed.");
            return Ok("User created successfully");
        }



        /// <summary>
        /// Login with existing user
        /// </summary>
        /// <param name="loginModel">username and password</param>
        /// <returns>access token "token" and referesh token "refereshToken"</returns>
        /// POST:/api/authentication/Login
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            var user = await _userManager.FindByNameAsync(loginModel.Username);
            if (user != null && await _userManager.CheckPasswordAsync(user, loginModel.Password))
            {
                var authClaims = await GetUserClaims(user);

                string token = GenerateToken(_configuration["JWT:TokenSecretKey"], 
                    DateTime.Now.AddMinutes(1), authClaims);
                
                string refereshToken = GenerateToken(_configuration["JWT:RefereshTokenSecretKey"], 
                    DateTime.Now.AddHours(6),new List<Claim> { authClaims[0] });

                return Ok(new
                {
                    token = token,
                    refereshToken = refereshToken
                });
            }
            return Unauthorized();
        }

        private async Task<List<Claim>> GetUserClaims(AppUser user)
        {
            var userRoles = await _userManager.GetRolesAsync(user);
            var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };
            foreach (var role in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role));
            }
            return authClaims;
        }

        private string GenerateToken(string securityKey, DateTime expiration, List<Claim> claims)
        {
            var authSigninKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
            var token = new JwtSecurityToken
            (
                expires: expiration,
                claims: claims,
                signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256)
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public class RefereshModel
        {
            public string RefereshToken { get; set; }
        }

        /// <summary>
        /// Uses the referesh token to generate a new access token
        /// /// </summary>
        /// <returns>access token "token" and referesh token "refereshToken"</returns>
        /// POST:/api/authentication/RefereshToken
        [HttpPost]
        [Route("RefereshToken")]
        public async Task<IActionResult> RefereshToken([FromBody] RefereshModel refereshModel)
        {
            if (String.IsNullOrEmpty(refereshModel.RefereshToken)) return BadRequest("Referesh token is null or empty.");
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            TokenValidationParameters parameters = new TokenValidationParameters
            {
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:RefereshTokenSecretKey"])),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            };
            try
            {
                SecurityToken securityToken;
                var principal = tokenHandler.ValidateToken(refereshModel.RefereshToken, parameters, out securityToken);
                var jwtSecurityToken = securityToken as JwtSecurityToken;
                if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                    return BadRequest("Token is invalid.");

                var username = principal.FindFirstValue(ClaimTypes.Name);
                var user = await _userManager.FindByNameAsync(username);

                var authClaims = await GetUserClaims(user);

                string newAccessToken = GenerateToken(_configuration["JWT:TokenSecretKey"],
                    DateTime.Now.AddMinutes(1), authClaims);

                string newRefreshToken = GenerateToken(_configuration["JWT:RefereshTokenSecretKey"],
                    DateTime.Now.AddHours(6), new List<Claim> { authClaims[0] });

                return Ok(new
                {
                    token = newAccessToken,
                    refereshToken = newRefreshToken
                });
            }
            catch (Exception e)
            {
                return BadRequest("Token is not valid");
            }
        }
    }
}
