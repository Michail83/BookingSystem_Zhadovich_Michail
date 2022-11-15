using BookingSystem.BusinessLogic.Services.Paypal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BookingSystem.WEB.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayPalController : ControllerBase
    {
        private readonly PayPalService _payPalService;
        public PayPalController(PayPalService payPalService)
        {
            _payPalService = payPalService;
        }

        [Route("CreateOrder")]
        [HttpPost]
        public async Task<string> CreateOrder([FromQuery] int orderId)
        {
            var response = await _payPalService.CreatePaymentAsync(orderId, GetCurrentUserEmail());

            return response;
        }

        [Route("CaptureOrder")]
        [HttpPost]
        public async Task<IActionResult> Capture([FromQuery] string id)
        {
            var result = await _payPalService.CapturePayment(id, GetCurrentUserEmail());
            return Ok(result);
        }

        private string GetCurrentUserEmail()
        {
            return HttpContext.User.FindFirstValue(ClaimTypes.Email);
        }
    }
}
