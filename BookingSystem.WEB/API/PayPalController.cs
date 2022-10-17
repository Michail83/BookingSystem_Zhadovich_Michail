using BookingSystem.WEB.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BookingSystem.BusinessLogic.Services;
using BookingSystem.BusinessLogic.Services.Paypal;
using System.Security.Claims;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace BookingSystem.WEB.API
{
    [Route("api/[controller]")]
    [ApiController]

   
    public class PayPalController : ControllerBase
    {
        private readonly PayPalAuthService _payPalAuthService;
        private readonly PayPalService _payPalService;
        public PayPalController(PayPalAuthService payPalAuthService, PayPalService payPalService) 
        {
            _payPalAuthService = payPalAuthService;
            _payPalService=payPalService;
        }

     

        [Route("CreateOrder")]
        [HttpPost]
        public async Task<string> CreateOrder([FromQuery] int orderId) 
        {
          var response = await  _payPalService.CreateOrderAsync(orderId, GetCurrentUserEmail());

            return response;
        }

        [Route("CaptureOrder")]
        [HttpPost]
        public async Task<IActionResult> Capture([FromQuery]string id)
        {
            var result = await _payPalService.CapturePayment(id, GetCurrentUserEmail());

            //var json = (JObject)JsonConvert.DeserializeObject(result);
            //var jtokenCaptures = json["purchase_units"][0]["payments"]["captures"][0];

            //var success = jtokenCaptures["status"].Value<string>();
            //var orderId = jtokenCaptures["custom_id"].Value<int>();

            return Ok(result);
        }

        private string GetCurrentUserEmail()
        {
            return HttpContext.User.FindFirstValue(ClaimTypes.Email);
        }



    }
}
