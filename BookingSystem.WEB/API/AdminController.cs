using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization; 
using Microsoft.IdentityModel.Tokens;

using BookingSystem.Infrastructure.IdentityDBContext;
using BookingSystem.Infrastructure.Models;
using BookingSystem.Infrastructure.JWT;
using BookingSystem.Infrastructure.Services;
using BookingSystem.Infrastructure.Interfaces;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookingSystem.WEB.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        UserManager<User> _usermanager;
        //RoleManager<IdentityRole> _rolemanager;


        public AdminController(UserManager<User> usermanager/*, RoleManager<IdentityRole> rolemanager*/)
        {
            _usermanager = usermanager;
            //_rolemanager = rolemanager;
        }

        [Route("login")]
        [HttpPost]
        public async Task<ActionResult> Login([FromForm] string username, [FromForm] string password, [FromServices] IJWTTokenProvider jwtTokenProvider)
        {
            string incorrect = "Incorrect Login or password";
            //extract
            var user = await _usermanager.FindByNameAsync(username);
            if (user==null)
            {
                return BadRequest(incorrect);
            }
            var result = _usermanager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, password);
            if (result != PasswordVerificationResult.Success)
            {
                return BadRequest(incorrect);
            }

            //user is cheked for "null"
            var token = jwtTokenProvider.GetSecurityToken(user);

            //var jwt = new JwtSecurityToken(
            //    issuer: JWTOptions.ISSUER,
            //    audience: JWTOptions.AUDIENCE,
            //    expires: DateTime.Now.Add(TimeSpan.FromMinutes(JWTOptions.LIFETIME)),
            //    notBefore: DateTime.Now,
            //    claims: identityclaims.Claims,
            //    signingCredentials: new SigningCredentials(JWTOptions.GetSymmetricSecurityKey(),SecurityAlgorithms.HmacSha256Signature)
            //    );
            //var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = token,
                username = user.UserName
            };
            return Ok(response);
        }

        [Authorize]
        [Route("Test")]
        [HttpGet]
        public ActionResult<string> Test()
        {
            HttpContext.Request.Headers.TryGetValue("Authorization", out var value);
            return Ok(" successful+    " + value.ToString());
        }
        //[Authorize]
        [Route("TestUser")]
        //[HttpGet]
        public ActionResult<string> TestUser()
        {
            HttpContext.Request.Headers.TryGetValue("Authorization", out var value);
            var one =  User.Identity.AuthenticationType.ToString();
            var two = User.Identity.Name;
            var three = User.IsInRole("admin");
            return Ok($" successful  = {one}  =  {two}  =  {three}" );
        }

        //[Authorize]
        [Route("getlogin")]
        public IActionResult GetLogin()
        {
            return Ok($"Ваш логин: {User.Identity.Name}");
        }



        // GET api/<AdminController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AdminController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AdminController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AdminController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private async Task<ClaimsIdentity>  GetClaimsIdentity(User user)
        {
            var roles = await _usermanager.GetRolesAsync(user);
            var claims = new List<Claim> {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.UserName)
            };

            //////  if roles=null ???
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimsIdentity.DefaultRoleClaimType, role));
            }
            ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);            
            return claimsIdentity;
        }
    }
}
