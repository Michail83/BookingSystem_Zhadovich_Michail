using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookingSystem.BusinessLogic.BusinesLogicModels;
using BookingSystem.BusinessLogic.Services;
using System.Threading.Tasks;
using System.Collections.Generic;
using BookingSystem.BusinessLogic.Interfaces;
using BookingSystem.WEB.Models;
using Microsoft.AspNetCore.Cors;

namespace BookingSystem.WEB.API
{
    [Route("CheckCartItem")]
    [ApiController]
    [EnableCors("LocalForDevelopmentAllowAll")]
    public class CartController : ControllerBase
    {
        CheckCartItemService _checkCartItemService;
        IMapper<ArtEventBL, ArtEventViewModel> _mapperToViewModel;
        public CartController(CheckCartItemService checkCartItemService, IMapper<ArtEventBL, ArtEventViewModel> mapperToViewModel )
        {
            _checkCartItemService = checkCartItemService;
            _mapperToViewModel = mapperToViewModel;
        }

        //[Route("CheckCartItem")]
        [HttpGet]
        public async Task<ActionResult<CheckCartResult>> CheckCartItem([FromQuery]CartItem cartItem) 
        {
            var result = await _checkCartItemService.CheckCartItem(cartItem);
            return Ok(result);
        }
        [Route(nameof(GetCurrentListOfArtEvent))]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArtEventViewModel>>> GetCurrentListOfArtEvent([FromQuery]IEnumerable<int> id) 
        {

            var listOfArtEvents = await _checkCartItemService.GetListOfArtEventsForReactCart(id);
            List<ArtEventViewModel> listOfArtEventsForReactCart = new();
            foreach (var artEventBL in listOfArtEvents)
            {
                listOfArtEventsForReactCart.Add(_mapperToViewModel.Map(artEventBL));

            }
            return Ok(listOfArtEventsForReactCart);
        }
    }
}
