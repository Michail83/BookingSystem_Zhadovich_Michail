
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

using System.Security.Claims;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Cors;


using Microsoft.AspNetCore.Authorization;

using Microsoft.Extensions.Configuration;

using BookingSystem.Infrastructure.Models;
using BookingSystem.Infrastructure.Interfaces;


namespace BookingSystem.WEB.API
{
    [Route("account")]
    [ApiController]
    [EnableCors("LocalForDevelopmentAllowAll")]

    public class AccountController : ControllerBase
    {
        public AccountController([FromServices] IJWTTokenProvider jwtTokenProvider,
                                 [FromServices] IConfiguration configuration,
                                 SignInManager<User> signInManager, 
                                 UserManager<User> userManager
            )
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _jwtTokenProvider = jwtTokenProvider;
            _configuration = configuration;


        }
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IJWTTokenProvider _jwtTokenProvider;
        private readonly IConfiguration _configuration;



        [HttpGet]
        [Route("GetExternalProviders")]
        public async Task<IEnumerable<string>> GetExternalProviders()
        {
            var providers = (await _signInManager.GetExternalAuthenticationSchemesAsync()).Select((provider)=>(provider.Name));
            return providers;
        }

        [HttpGet]
        [Route("externallogin")]
        public IActionResult ExternalLogin([FromQuery]string provider, string returnUrl = null) 
        {
            
            var redirectUrl = Url.Action(nameof(ExternalLoginCallback),"account", new {returnUrl });
            // вызов с передачей имени провайдера
            var prop = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);

            return Challenge(prop, provider);
        }
        //public IActionResult ExternalLogin([FromForm] string provider, string returnUrl = null)
        //{

        //    var redirectUrl = Url.Action(nameof(ExternalLoginCallback), "account", new { returnUrl });
        //    // вызов с передачей имени провайдера
        //    var prop = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);

        //    return Challenge(prop, provider);
        //}

        [Route("externallogincallback")]
        public async Task<IActionResult> ExternalLoginCallback(string returnUrl = "http://localhost:5001/")
        {
            var info = await _signInManager.GetExternalLoginInfoAsync();
            var email = info?.Principal?.FindFirstValue(ClaimTypes.Email);

            if (info == null || email == null)  
            {
                return BadRequest("GetExternalLoginInfoAsync  ERROR");
                //return Redirect(returnUrl);
            }
                                                                                                                                        //true
            var signInResult = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent:false, bypassTwoFactor:false);
            if (signInResult.Succeeded)
            {
                User user =  await _userManager.FindByEmailAsync(email);
                return Redirect("https://localhost:5001/");
                //return Redirect(GetUrlWithJWTToken(user))/* Ok($"Succeeded,   signIn result=  {info.LoginProvider} ")*/;
            }

            if (signInResult.IsLockedOut)
            {
                return BadRequest("IsLockedOut");
                //return RedirectToAction(nameof(ForgotPassword));
            }
            else
            {
                
                //var email = info.Principal.FindFirst(ClaimTypes.Email).Value;
                //if (email == null)
                //{
                //    return BadRequest("not find Email");
                //}

                User user = await _userManager.FindByEmailAsync(email);
                IdentityResult result;
                if (user != null)
                {
                    result = await _userManager.AddLoginAsync(user, info);
                    if (result.Succeeded)
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return Redirect("https://localhost:5001/");
                        //return Redirect(GetUrlWithJWTToken(user));
                    }
                }
                
                else
                {
                    user = new User 
                    {
                        Email = info.Principal.FindFirst(ClaimTypes.Email).Value,
                        UserName = info.Principal.FindFirst(ClaimTypes.GivenName).Value.Trim(new char[] {'\"' })                        
                    };                    

                    result = await _userManager.CreateAsync(user);
                    if (result.Succeeded)
                    {
                        result = await _userManager.AddLoginAsync(user, info);
                        if (result.Succeeded)
                        {
                            //TODO: Send an emal for the email confirmation and add a default role as in the Register action
                            await _signInManager.SignInAsync(user, isPersistent: false);
                            return Redirect("https://localhost:5001/");
                            //return Redirect(GetUrlWithJWTToken(user));
                        }
                    }
                }                
                return BadRequest("ExternalLoginCallback  =  last else");
            }            
        }

        [Authorize]
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();            
            return Ok();
        }
        [EnableCors("LocalForDevelopmentAllowAll")]
        //[Authorize]
        [Route("loginfo")]
        public  IActionResult LogInfo()
        {
           var email=   HttpContext.User.FindFirstValue(ClaimTypes.Email);
           var name = HttpContext.User.FindFirstValue(ClaimTypes.Name);
           return Ok(new {email, name });
        }

        private string GetUrlWithJWTToken(User user, string urlRedirect = null)
        {
            var token =  _jwtTokenProvider.GetSecurityToken(user);
            var url = _configuration.GetSection("ReactInfo")["CallBackUrlForToken"];
            url += token;
            return url;
        }

    }
}
