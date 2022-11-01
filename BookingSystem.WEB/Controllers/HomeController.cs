using BookingSystem.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace BookingSystem.WEB.Controllers
{
    [Route("home")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<User> _userManager;

        public HomeController(ILogger<HomeController> logger, UserManager<User> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        [Route("resetpassword")]
        [HttpGet]

        public async Task<IActionResult> ResetPassword(string token, string email)
        {

            var user = await _userManager.Users.FirstOrDefaultAsync(user => user.NormalizedEmail == email.ToUpper());
            if (user != null)
            {
                if (await _userManager.VerifyUserTokenAsync(user, _userManager.Options.Tokens.PasswordResetTokenProvider, UserManager<User>.ResetPasswordTokenPurpose, token))
                {
                    ViewBag.email = user.Email;
                    return View();
                }
            }
            return BadRequest();
        }
    }
}
