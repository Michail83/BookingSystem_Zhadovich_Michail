using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


using System.Threading.Tasks;
using System.Security.Claims;
using System.Collections.Generic;
using System.Linq;


using BookingSystem.BusinessLogic.Services;
using BookingSystem.BusinessLogic.BusinesLogicModels;
using BookingSystem.BusinessLogic.Interfaces;
using BookingSystem.WEB.Models;
using BookingSystem.WEB.Services;

namespace BookingSystem.WEB.API
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        OrderBLService _orderBLService;
        //string currentUsersEmail;
        MapperOrderBLtoViewModel mapperOrderBLtoViewModel;

        public OrderController(OrderBLService orderBLService, IMapper<ArtEventBL, ArtEventViewModel> artMapper) 
        {
            _orderBLService = orderBLService;
            mapperOrderBLtoViewModel = new MapperOrderBLtoViewModel(artMapper);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync([FromQuery] int id)
        {
            var orderBl = await _orderBLService.GetAsync(id, GetCurrentUserEmail());
            return Ok(orderBl);
        }
        [Route("GetAsync")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {            
            var resultBL = await _orderBLService.GetAllAsync(GetCurrentUserEmail());           
            var resultViewModel = mapperOrderBLtoViewModel.Map(resultBL);
            return Ok(resultViewModel);
        }


        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]IEnumerable<OrderData> orderData) 
        {
            //string currentUsersEmail = HttpContext.User.FindFirstValue(ClaimTypes.Email);
            if (orderData.Count() ==0)
            {
                return BadRequest("No orderData");
            }                        
            List<CartWithQuantityBL> cartWithQuantityBLs = new();
            foreach (var ord in orderData)
            {
                cartWithQuantityBLs.Add(new CartWithQuantityBL { Quantity = ord.Quantity, ArtEventBL = new ArtEventBL { Id = ord.EventId } });
            }
            OrderBL orderBL = new OrderBL {UserEmail = GetCurrentUserEmail(), ListOfReservedEventTickets = cartWithQuantityBLs };
            await _orderBLService.CreateAsync(orderBL);

            return Ok();
        }
        private string GetCurrentUserEmail() 
        {
            return HttpContext.User.FindFirstValue(ClaimTypes.Email);
        }


    }
}
