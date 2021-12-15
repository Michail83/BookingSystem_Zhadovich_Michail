using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BookingSystem.DataLayer;
using BookingSystem.BusinessLogic.Interfaces;
using BookingSystem.BusinessLogic.Services;
using BookingSystem.DataLayer.EntityModels;
using BookingSystem.BusinessLogic.BusinesLogicModels;
using BookingSystem.DataLayer.EntityFramework.Repository;
using Microsoft.EntityFrameworkCore;
using BookingSystem.WEB.Models;
using System.Text.Json.Serialization;
using System.Text.Json;



namespace BookingSystem.WEB.API
{
    [Route("apiArtEvents")]
    [ApiController]
    public class ArtEventsController : ControllerBase
    {
        IBusinessLayerCRUDServiceAsync<ArtEventBL> _artEventBLService;
        IMapper<ArtEventBL, ArtEventViewModel> _mapperToViewModel;
        public ArtEventsController(IBusinessLayerCRUDServiceAsync<ArtEventBL> artEventBLService, IMapper<ArtEventBL, ArtEventViewModel> mapperToViewModel)
        {
            _artEventBLService = artEventBLService;
            _mapperToViewModel = mapperToViewModel;
        }
        // GET: api/<ArtEventsController>        
        //[Produces("application/json")]
        [Route("GetAllArtEvents")]
        [HttpGet]
        public async Task<ActionResult<ArtEventViewModel>> Get([FromQuery] PagesState pageStatus = null)
        {
            PagesState _artEventBLPagesStatus = pageStatus ?? new PagesState();
            var QueryResult = await _artEventBLService.GetAllAsync(_artEventBLPagesStatus);
            List<ArtEventViewModel> response = new();

            foreach (var item in QueryResult)
            {
                response.Add(_mapperToViewModel.Map(item));
            }
            var pageInfo = new
            {
                QueryResult.TotalItemsCount,
                QueryResult.PageSize,
                QueryResult.CurrentPage,
                QueryResult.TotalPages,
                QueryResult.HasNext,
                QueryResult.HasPrevious
            };
            HttpContext.Response.Headers.Add("PageStateInfo", JsonSerializer.Serialize(pageInfo));
            return Ok(response);
        }

        
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<ArtEventBL>>> Get()
        //{
        //    return  await _artEventBLService.GetAll(null); ;
        //}

        // GET api/<ArtEventsController>/5
        [HttpGet]
        [Route("GetArtEvents")]
        public async Task<ArtEventViewModel> Get(int id)
        {
            return _mapperToViewModel.Map(await _artEventBLService.GetAsync(id));
        }

        //// POST api/<ArtEventsController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<ArtEventsController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<ArtEventsController>/5
        [HttpDelete]
        public async Task Delete([FromQuery]int id)
        {
           await _artEventBLService.DeleteAsync(id);
        }
    }
}
