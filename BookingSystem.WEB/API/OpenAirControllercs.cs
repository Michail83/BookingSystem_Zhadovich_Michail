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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookingSystem.WEB.API
{
    [Route("api/openair")]
    [ApiController]
    public class OpenAirControllercs : ControllerBase
    {
        IBusinessLayerCRUDServiceAsync<OpenAirBL> _openAirService;
        

        public OpenAirControllercs(IBusinessLayerCRUDServiceAsync<OpenAirBL> openAirService)
        {
            _openAirService = openAirService;
        }

        [Route("GetAllWithPageState")]
        [HttpGet]
        public ActionResult Get([FromQuery]PagesState pageState)
        {
            //var queryResult = await _openAirService.GetAllAsync(pageState);

            //var pageInfo = new
            //{
            //    queryResult.TotalItemsCount,
            //    queryResult.PageSize,
            //    queryResult.CurrentPage,
            //    queryResult.TotalPages,
            //    queryResult.HasNext,
            //    queryResult.HasPrevious
            //};
            //HttpContext.Response.Headers.Add("PageStateInfo", JsonSerializer.Serialize(pageInfo));
            return RedirectToAction("Get", "ArtEventsController"); //Not Found???            
        }


        // GET api/<OpenAirControllercs>/5
        [HttpGet]
        public async Task<OpenAirBL> Get(int id)
        {
           return await _openAirService.GetAsync(id); //Not Found???            
        }

        // POST api/<OpenAirControllercs>
        [HttpPost]
        public async Task Post([FromForm] OpenAirBL openAirBL)
        {
            await _openAirService.CreateAsync(openAirBL);
        }

        // PUT api/<OpenAirControllercs>/5
        [HttpPut]
        public async Task Put([FromForm] OpenAirBL openAirBL)
        {
            await _openAirService.UpdateAsync(openAirBL);
        }

        // DELETE api/<OpenAirControllercs>/5
        [HttpDelete("{id}")]
        public ActionResult Delete([FromQuery]int id)
        {
            return RedirectToAction("Delete", "ArtEventsController");
        }
    }
}
