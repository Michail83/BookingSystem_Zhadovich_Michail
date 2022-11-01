
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using BookingSystem.BusinessLogic.Services;

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
                                 IWebHostEnvironment env,
                                 OrderBLService orderBLService,
                                 IMapper mapper
            )
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _configuration = configuration;
            _emailService = emailService;
            _mapper = mapper;
            _orderBLService=orderBLService;

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
        private readonly IConfiguration _configuration;
        private readonly IEmailService _emailService;
        private readonly string _hostsUrl;
        private readonly IMapper _mapper;
        private readonly OrderBLService _orderBLService;


        [HttpGet]
        [Route("RefreshConfirmationToken")]
        public async Task<ActionResult> RefreshConfirmationToken(string email)
        {
            bool success = false;
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null && !user.EmailConfirmed)
            {
                var newConfirmationTokenTime = (user.ConfirmationTokenCreationTime ?? new DateTime(2000, 01, 01, 0, 0, 0)).AddMinutes(10);

                if (newConfirmationTokenTime < DateTime.Now)
                {
                    var mailRequest = await CreateConfirmationEmailRequestAsync(user);
                    success = await _emailService.SendEmailAsync(mailRequest);
                    return Ok(new { success = true, CanTryIn = "" });
                }
                else
                {
                    return Ok(new { success = false, CanTryIn = newConfirmationTokenTime });
                }

            }
            return Ok(new { success = false, CanTryIn = "" });
        }

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
                bool isDuplicateEmail = creationResult.Errors.FirstOrDefault(
                    error => error.Code.ToLower(System.Globalization.CultureInfo.InvariantCulture)
                    ==
                    "DuplicateEmail".ToLower(System.Globalization.CultureInfo.InvariantCulture)) != null;

                bool isDuplicateUserName = creationResult.Errors.FirstOrDefault(
                    error => error.Code.ToLower(System.Globalization.CultureInfo.InvariantCulture)
                    ==
                    "DuplicateUserName".ToLower(System.Globalization.CultureInfo.InvariantCulture)) != null;


                if (isDuplicateEmail)
                {
                    return BadRequest(new[] { new { code = "EmailAlreadyExist", description = "This Email already exist", lastconfirmationTime = user.ConfirmationTokenCreationTime } });
                }
                else if (isDuplicateUserName)
                {
                    return BadRequest(new[] { new { code = "NameAlreadyExist", description = "This user name already exist" } });
                }
                return BadRequest(creationResult.Errors);

            }

            var mailRequest = await CreateConfirmationEmailRequestAsync(user);


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
            if (confirmResult.Succeeded == true)
            {
                await _signInManager.SignInAsync(user, false);
                return Redirect(_hostsUrl);
            }


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

            var user = await _userManager.FindByEmailAsync(loginViewModel.Email);

            if (user == null)
            {
                return BadRequest(new { code = "wronglogin", description = "Email or password wrong" });
            }

            var result = await _signInManager.PasswordSignInAsync(user.UserName, loginViewModel.Password, loginViewModel.RememberMe, false);
            if (result.Succeeded)
            {
                return Ok("Login success");
            }
            else if (!await _userManager.IsEmailConfirmedAsync(user))
            {
                return BadRequest(new { code = "notconfirmed", description = "This email is not confirmed" });
            }
            else if (!(await _userManager.HasPasswordAsync(user)))
            {
                bool sendResult =  await CreateAndSendPasswordResetToken(user.Email);

                return BadRequest(new { code = "noPassword", description = "Password was resetted. Email with link to recover page was sended" });
            }
            
            return BadRequest(new { code = "wronglogin", description = "Email or password wrong" });
            
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

            var redirectUrl = Url.Action(nameof(ExternalLoginCallback), "account", null, Request.Scheme);
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
        public async Task<IActionResult> LogInfo()
        {
            var userEmail = HttpContext.User.FindFirstValue(ClaimTypes.Email);
            var userName = HttpContext.User.FindFirstValue(ClaimTypes.Name);
            var isAdmin = HttpContext.User.IsInRole("admin");
            var user = await _userManager.FindByEmailAsync(userEmail);

            var isLocked = user?.IsLocked;

            var isAuthenticated = true;
            return Ok(new { isAuthenticated, userEmail, userName, isAdmin, isLocked });
        }


        [Authorize(Roles = "admin")]
        [Route("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var users = _userManager.Users.Where((user)=> user.NormalizedEmail != HttpContext.User.FindFirstValue(ClaimTypes.Email).ToUpper()).ToList();
           
            List<UserViewModel> userViewModels = new();

            foreach (var user in users)
            {
                var userV = _mapper.Map<UserViewModel>(user);
                userV.OrdersCount = await _orderBLService.GetOrdersCount(userV.Email);
                userV.HasPassword = await _userManager.HasPasswordAsync(user);

                userViewModels.Add(userV);
            }
            return Ok(userViewModels);
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        [Route("ToogleLockUser")]
        public async Task<IActionResult> ToogleLockUser(string Id)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(user=>user.Id == Id);
            if (user==null)            
                return BadRequest();

            user.IsLocked = !user.IsLocked;
            await _userManager.UpdateAsync(user);
           
            return Ok(_mapper.Map<UserViewModel>(user));
        }
        [HttpGet]
        [Route("SendPasswordResetToken")]
        public async Task<IActionResult> SendPasswordResetToken(string email)
        {
           var result =   await CreateAndSendPasswordResetToken(email);
            return Ok();
        }
        private async Task<bool> CreateAndSendPasswordResetToken(string email) 
        {

            var user = await _userManager.Users.FirstOrDefaultAsync(user => user.Email.Equals(email, StringComparison.InvariantCultureIgnoreCase));

            bool result=false;
            if (user != null && !(await _userManager.IsInRoleAsync(user, "admin")))
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var passwordResetLink = Url.Action("ResetPassword", "Home", new { token, email = user.Email }, Request.Scheme);
                var mailBody = $"<a href=\"{passwordResetLink} \"> Go to recover page</a>";

                var mailRequest = new MailRequest { ToEmail = user.Email, Body = mailBody, Subject = "bookingsystem-zhadovichmichail.herokuapp.com" };

                result = await _emailService.SendEmailAsync(mailRequest, true);
            }

            return result;
        }


        [Authorize(Roles = "admin")]
        [HttpGet]
        [Route("RemovePassword")]
        public async Task<IActionResult> RemovePassword(string email)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(user => user.Email.Equals(email, StringComparison.InvariantCultureIgnoreCase));
            //var isAdmin = await _userManager.IsInRoleAsync(user, "admin");
            //var haspassword = await _userManager.HasPasswordAsync(user);

            if (user != null && !(await _userManager.IsInRoleAsync(user, "admin")) && (await _userManager.HasPasswordAsync(user)))
            {
                var result =  await _userManager.RemovePasswordAsync(user);
                var haspassword2 = await _userManager.HasPasswordAsync(user);
                return Ok(result);
            }
            return Ok();
        }

        [HttpPost]
        [Route("SetNewPasswordWithToken")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SetNewPasswordWithToken([FromForm]ChangePasswordModel model)
        {
            if (model?.Email==null)
            {
                return BadRequest();
            }
            var user = await _userManager.FindByEmailAsync(model.Email.ToUpper());
            if (user==null)
            {
                return BadRequest();
            }

           var removeResult =  await _userManager.RemovePasswordAsync(user);

            var addResult = await _userManager.AddPasswordAsync(user, model.NewPassword);

            if (addResult.Succeeded)
            {
                await _signInManager.SignInAsync(user, true);
                return Redirect(_hostsUrl);
            }
            
            return Ok();
        }



        /// <summary>
        /// Create new  <see cref="MailRequest"/> with confirmation link for the specified user 
        /// <para>
        /// !!!  set new ConfirmationTokenCreationTime  for <paramref name="user"/>
        /// </para>
        /// </summary>
        /// <param name="user"></param>
        /// <returns><see cref="MailRequest"/>  for SendEmailService </returns>
        /// <exception cref="ArgumentException"> if email is null or confirmed</exception>
        private async Task<MailRequest> CreateConfirmationEmailRequestAsync(User user)
        {
            if (user == null || user.EmailConfirmed)
            {
                throw new ArgumentException();
            }

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var emailConfirmationLink = Url.Action("ConfirmEmail", "account", new { token, email = user.Email }, Request.Scheme);

            user.ConfirmationTokenCreationTime = DateTime.Now;
            await _userManager.UpdateAsync(user);

            var mailRequest = new MailRequest { ToEmail = user.Email, Body = emailConfirmationLink, Subject = " test Booking system Email confirmation" };

            return mailRequest;
        }

    }
}
