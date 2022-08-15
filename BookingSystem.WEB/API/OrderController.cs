﻿using BookingSystem.BusinessLogic.BusinesLogicModels;
using BookingSystem.BusinessLogic.Interfaces;
using BookingSystem.BusinessLogic.Services;
using BookingSystem.WEB.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BookingSystem.WEB.API
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        OrderBLService _orderBLService;
        //string currentUsersEmail;
        IMapper<OrderBL, OrderViewModel> _mapperOrderBLtoViewModel;


        public OrderController(
            OrderBLService orderBLService,
            //IMapper<ArtEventBL, ArtEventViewModel> artMapper,
            IMapper<OrderBL, OrderViewModel> orderToViewModelMapper
            )
        {
            _orderBLService = orderBLService;
            _mapperOrderBLtoViewModel = orderToViewModelMapper;



        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync([FromQuery] int id)
        {
            var orderBl = await _orderBLService.GetAsync(id, GetCurrentUserEmail());
            var result = _mapperOrderBLtoViewModel.Map(orderBl);
            return Ok(result);
        }
        [Route("GetAsync")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var resultBL = await _orderBLService.GetAllAsync(GetCurrentUserEmail());
            var resultViewModel = new List<OrderViewModel>();

            foreach (var item in resultBL)
            {
                resultViewModel.Add(_mapperOrderBLtoViewModel.Map(item));
            }
            return Ok(resultViewModel);
        }


        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] IEnumerable<OrderData> orderData)
        {
            //string currentUsersEmail = HttpContext.User.FindFirstValue(ClaimTypes.Email);
            if (orderData.Count() == 0)
            {
                return BadRequest("No orderData");
            }
            List<CartWithQuantityBL> cartWithQuantityBLs = new();
            foreach (var ord in orderData)
            {
                cartWithQuantityBLs.Add(new CartWithQuantityBL { Quantity = ord.Quantity, ArtEventBL = new ArtEventBL { Id = ord.EventId } });
            }
            OrderBL orderBL = new OrderBL { UserEmail = GetCurrentUserEmail(), ListOfReservedEventTickets = cartWithQuantityBLs, TimeOfCreation = System.DateTime.Now };
            await _orderBLService.CreateAsync(orderBL);

            return Ok();
        }
        private string GetCurrentUserEmail()
        {
            return HttpContext.User.FindFirstValue(ClaimTypes.Email);
        }
    }
}
