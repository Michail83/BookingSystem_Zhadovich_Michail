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
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.WebUtilities;
using BookingSystem.DataLayer.Exceptions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookingSystem.WEB.API
{
    [Route("Parties")]
    [ApiController]
    [EnableCors("LocalForDevelopmentAllowAll")]
    public class PartyController : ControllerBase
    {
        IBusinessLayerCRUDServiceAsync<PartyBL> _partyService;        

        public PartyController(IBusinessLayerCRUDServiceAsync<PartyBL> openAirService)
        {
            _partyService = openAirService;
        }
        
        [HttpGet]
        public ActionResult Get([FromQuery]PagesState pageState = null)
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

            var searchParams =  Request.Query;

            var uri= QueryHelpers.AddQueryString("https://localhost:44324/ArtEvents", searchParams);
            return Redirect(uri);   // how to use redirect to action/route

                //RedirectToAction("Get", "ArtEventsController", pageState);             
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<OpenAirBL>> Get(int id)
        {
            try
            {
                var result  = await _partyService.GetAsync(id);
                return Ok(result);
            }
            catch (EventNotFoundException ex)
            {
                System.Diagnostics.Debug.WriteLine(this.GetType() + ex.Message);   //ToDo  delete after
                return NotFound($"ArtEvent { id}  not found");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(this.GetType() + ex.Message);   //ToDo  delete after
                return BadRequest();
            }                       
        }
        
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] PartyBL partyBL)
        {
            try
            {
                await _partyService.CreateAsync(partyBL);   //ToDO  -  validate parameter,
                return Ok(partyBL);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(this.GetType() + ex.Message);   //ToDo  delete after
                return BadRequest("read debug");                 
            }
        }
        
        [HttpPut]
        public async Task<ActionResult> Put([FromForm] PartyBL partyBL)
        {
            try
            {
                await _partyService.UpdateAsync(partyBL);    //ToDo  validate
                return Ok();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(this.GetType() + ex.Message);   //ToDo  delete after
                return BadRequest("read debug");
            }            
        }        
        [HttpDelete]
        public ActionResult Delete([FromQuery]int id)
        {
            return  NoContent();
            //RedirectToAction("Delete", "ArtEventsController", id);
        }
    }
}
