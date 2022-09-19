//using Microsoft.AspNetCore.Authentication;
//using Microsoft.AspNetCore.Authentication.Cookies;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using System.Threading.Tasks;

//namespace BookingSystem.WEB.API
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class AdminController : ControllerBase
//    {
//        //UserManager<User> _usermanager;
//        //RoleManager<IdentityRole> _rolemanager;

//        /*UserManager<User> usermanager*//*, RoleManager<IdentityRole> rolemanager*/
//        public AdminController()
//        {
//            //_usermanager = usermanager;
//            //_rolemanager = rolemanager;
//        }


//        [Authorize]
//        [Route("Test")]
//        [HttpGet]
//        public async Task<ActionResult<string>> Test()
//        {
//            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
//            return Ok($"{result.Succeeded }+ {User.Identity.IsAuthenticated}  +{User.Identity.Name}");
//        }

//        [Authorize]
//        [Route("TestUser")]
//        [HttpGet]
//        public ActionResult<string> TestUser()
//        {
//            var one = User.Identity.AuthenticationType.ToString();
//            var two = User.Identity.Name;
//            var three = User.IsInRole("admin");
//            return Ok($" AuthenticationType= {one}  Identity.Name  {two} IsInRole admin  {three}");
//        }

//        ////[Authorize]
//        //[Route("getlogin")]
//        //public IActionResult GetLogin()
//        //{
//        //    return Ok($"Ваш логин: {User.Identity.Name}");
//        //}


//    }
//}
