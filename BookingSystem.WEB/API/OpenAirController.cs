using BookingSystem.BusinessLogic.BusinesLogicModels;
using BookingSystem.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;




namespace BookingSystem.WEB.API
{
    [Route("openAirs")]
    [ApiController]

    public class OpenAirController : ControllerBase
    {
        IBusinessLayerCRUDServiceAsync<OpenAirBL> _openAirService;

        public OpenAirController(IBusinessLayerCRUDServiceAsync<OpenAirBL> openAirService)
        {
            _openAirService = openAirService;
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
                var result = await _openAirService.GetAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(this.GetType() + ex.Message);   // ToDo  delete after
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OpenAirBL openAirBL)
        {
            try
            {
                await _openAirService.CreateAsync(openAirBL);   // ToDO  -  validate parameter,
                return Ok(openAirBL);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(this.GetType() + ex.Message);   // ToDo  delete after
                return BadRequest("read debug");
                throw;
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromForm] OpenAirBL openAirBL)
        {
            try
            {
                await _openAirService.UpdateAsync(openAirBL);    // ToDo  validate
                return Ok();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(this.GetType() + ex.Message);   // ToDo  delete after
                return BadRequest("read debug");
            }
        }

        [HttpDelete]
        public ActionResult Delete([FromQuery] int id)
        {
            return BadRequest();
        }
    }
}
