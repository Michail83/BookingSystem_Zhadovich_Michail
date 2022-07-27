using BookingSystem.BusinessLogic.BusinesLogicModels;
using BookingSystem.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;

using System;
using System.Threading.Tasks;

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
        public ActionResult Get([FromQuery] PagesState pageState = null)
        {
            return BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OpenAirBL>> Get(int id)
        {
            try
            {
                var result = await _partyService.GetAsync(id);
                return Ok(result);
            }
            
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(this.GetType() + ex.Message);   //ToDo  delete after
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PartyBL partyBL)
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
        public ActionResult Delete([FromQuery] int id)
        {
            return NoContent();
        }
    }
}
