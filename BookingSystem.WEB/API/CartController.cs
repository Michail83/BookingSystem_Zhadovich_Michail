using BookingSystem.BusinessLogic.BusinesLogicModels;
using BookingSystem.BusinessLogic.Interfaces;
using BookingSystem.BusinessLogic.Services;
using BookingSystem.WEB.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;

namespace BookingSystem.WEB.API
{
    [Route("CheckCartItem")]
    [ApiController]
    [EnableCors("LocalForDevelopmentAllowAll")]
    public class CartController : ControllerBase
    {
        CheckCartItemService _checkCartItemService;
        IMapper _mapper;
        public CartController(CheckCartItemService checkCartItemService, IMapper mapper)
        {
            _checkCartItemService = checkCartItemService;
            _mapper = mapper;
        }
        
        //[HttpGet]
        //public async Task<ActionResult<CheckCartResult>> CheckCartItem([FromQuery] CartItem cartItem)
        //{
        //    var result = await _checkCartItemService.CheckCartItem(cartItem);
        //    return Ok(result);
        //}


        [Route(nameof(GetCurrentListOfArtEvent))]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArtEventViewModel>>> GetCurrentListOfArtEvent([FromQuery] IEnumerable<int> ids)
        {
            var listOfArtEvents = await _checkCartItemService.GetListOfArtEventsForReactCart(ids);
            
            IEnumerable<ArtEventViewModel> listOfArtEventsForReactCart = _mapper.Map<IEnumerable<ArtEventViewModel>>(listOfArtEvents);
            
            return Ok(listOfArtEventsForReactCart);
        }
    }
}
