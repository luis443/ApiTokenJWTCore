using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TokenJWTWebAPi.Data;
using TokenJWTWebAPi.Model;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

namespace TokenJWTWebAPi.Controllers
{
    
    [Route("api/[controller]")]
    public class AuthController : Controller
    {



        private UserManager<ApplicationUser> userManager;

        public AuthController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;    
        }

     

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> login([FromBody] LoginModel model)
        {
            var user = await userManager.FindByNameAsync(model.UserName);

            if(user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
                };

                var signingkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MySuperSecurekey"));

                var token = new JwtSecurityToken(
                    issuer:"http://oec.com",
                    audience:"http://oec.com",
                    expires:DateTime.UtcNow.AddHours(1),
                    claims:claims,
                    signingCredentials:new SigningCredentials(signingkey, SecurityAlgorithms.HmacSha256)
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration= token.ValidTo
                });
            }
            return Unauthorized();
        }
    }
}