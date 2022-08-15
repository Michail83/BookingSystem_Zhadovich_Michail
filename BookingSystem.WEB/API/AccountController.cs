
using BookingSystem.BusinessLogic.BusinesLogicModels;
using BookingSystem.BusinessLogic.Interfaces;
using BookingSystem.Infrastructure.Interfaces;
using BookingSystem.Infrastructure.Models;
using BookingSystem.WEB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

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
                                 UserManager<User> userManager,
                                 IEmailService emailService,
                                 IWebHostEnvironment env
            )
        {
            _signInManager = signInManager;
            _userManager = userManager;
            //_jwtTokenProvider = jwtTokenProvider;
            _configuration = configuration;
            _emailService = emailService;
            if (env.IsDevelopment())
            {
                _hostsUrl = "/";
            }
            else
            {
                _hostsUrl = configuration.GetSection("BaseUri").Value;
                
            }


        }

        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        //private readonly IJWTTokenProvider _jwtTokenProvider;
        private readonly IConfiguration _configuration;
        private readonly IEmailService _emailService;
        private readonly string _hostsUrl;

        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult> Register(RegisterLoginViewModel regModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }

            User user = new User { UserName = regModel.UserName, Email = regModel.Email };
            var creationResult = await _userManager.CreateAsync(user, regModel.Password);

            if (!creationResult.Succeeded)
            {
                return BadRequest(creationResult.Errors);
            }
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var emailConfirmationLink =
                Url.Action("ConfirmEmail", "account",
                new { token, email = user.Email }, Request.Scheme);
            var mailRequest = new MailRequest { ToEmail = user.Email, Body = emailConfirmationLink, Subject = " test Booking system Email confirmation" };

            try
            {
                await _emailService.SendEmailAsync(mailRequest);
            }
            catch (System.Exception)
            {
                return StatusCode(503);
            }
            return Ok("email with confirmation link was sended");
        }

        [HttpGet]
        [Route("ConfirmEmail")]
        public async Task<ActionResult> ConfirmEmail(string token, string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return NotFound("User not found");
            }
            var confirmResult = await _userManager.ConfirmEmailAsync(user, token);

            return Ok(confirmResult);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult> Login(LoginViewModel loginViewModel)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }
            var users = _userManager.Users.ToList();
            var user = await _userManager.FindByEmailAsync(loginViewModel.Email);
            if (user == null)
            {
                return NotFound("email or password wrong");
            }

            if (await _userManager.IsEmailConfirmedAsync(user))
            {
                var result = await _signInManager.PasswordSignInAsync(user.UserName, loginViewModel.Password, loginViewModel.RememberMe, false);
                if (result.Succeeded)
                {
                    return Ok("Login success");
                }
                else
                {
                    return NotFound("email or password wrong");
                }
            }
            else
            {
                var notConfirmed = new[] { new { code = "", description = "Please, confirm your email" } };
                return BadRequest(notConfirmed);
            }
        }

        [HttpGet]
        [Route("GetExternalProviders")]
        public async Task<IEnumerable<string>> GetExternalProviders()
        {
            var providers = (await _signInManager.GetExternalAuthenticationSchemesAsync()).Select((provider) => (provider.Name));
            return providers;
        }

        [HttpGet]
        [Route("externallogin")]
        public IActionResult ExternalLogin([FromQuery] string provider, string returnUrl = null)
        {

            var redirectUrl = Url.Action(nameof(ExternalLoginCallback), "account", new { returnUrl });
            // вызов с передачей имени провайдера
            var prop = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);

            return Challenge(prop, provider);
        }

        [Route("externallogincallback")]
        public async Task<IActionResult> ExternalLoginCallback(string returnUrl = "/")
        {
            var info = await _signInManager.GetExternalLoginInfoAsync();
            var email = info?.Principal?.FindFirstValue(ClaimTypes.Email);

            if (info == null || email == null)
            {
                return BadRequest("GetExternalLoginInfoAsync  ERROR");
            }
            //true
            var signInResult = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: false);
            if (signInResult.Succeeded)
            {
                return Redirect(_hostsUrl);
            }
            if (signInResult.IsLockedOut)
            {
                return BadRequest("IsLockedOut");
            }
            else
            {
                User user = await _userManager.FindByEmailAsync(email);
                IdentityResult result;
                if (user != null)
                {
                    result = await _userManager.AddLoginAsync(user, info);
                    if (result.Succeeded)
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return Redirect(_hostsUrl);
                    }
                }

                else
                {
                    user = new User
                    {
                        Email = info.Principal.FindFirst(ClaimTypes.Email).Value,
                        UserName = info.Principal.FindFirst(ClaimTypes.GivenName).Value.Trim(new char[] { '\"' }),
                        EmailConfirmed = true,
                    };

                    result = await _userManager.CreateAsync(user);
                    if (result.Succeeded)
                    {
                        result = await _userManager.AddLoginAsync(user, info);
                        if (result.Succeeded)
                        {
                            await _signInManager.SignInAsync(user, isPersistent: false);
                            return Redirect(_hostsUrl);
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

        [Authorize]
        [Route("loginfo")]
        public IActionResult LogInfo()
        {
            var userEmail = HttpContext.User.FindFirstValue(ClaimTypes.Email);
            var userName = HttpContext.User.FindFirstValue(ClaimTypes.Name);
            var isAdmin = HttpContext.User.IsInRole("admin");
            var isAuthenticated = true;
            return Ok(new { isAuthenticated, userEmail, userName, isAdmin });
        }
    }
}
