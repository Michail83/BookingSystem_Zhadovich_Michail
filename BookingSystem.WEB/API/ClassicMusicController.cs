using BookingSystem.BusinessLogic.BusinesLogicModels;
using BookingSystem.BusinessLogic.Interfaces;

using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Threading.Tasks;

namespace BookingSystem.WEB.API
{
    [Route("ClassicMusic")]
    [ApiController]
    [EnableCors("LocalForDevelopmentAllowAll")]
    public class ClassicMusicController : ControllerBase
    {
        IBusinessLayerCRUDServiceAsync<ClassicMusicBL> _partyService;

        public ClassicMusicController(IBusinessLayerCRUDServiceAsync<ClassicMusicBL> openAirService)
        {
            _partyService = openAirService;
        }


        [HttpGet]
        public ActionResult Get([FromQuery] PagesState pageState = null)
        {
            return BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClassicMusicBL>> Get(int id)
        {
            try
            {
                var result = await _partyService.GetAsync(id);
                return Ok(result);
            }


            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(GetType() + "MESSAGE" + ex.Message);   //ToDo  delete after
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ClassicMusicBL classicMusicBL)
        {
            try
            {
                await _partyService.CreateAsync(classicMusicBL);   //ToDO  -  validate parameter,
                return Ok(classicMusicBL);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(this.GetType() + ex.Message);   //ToDo  delete after
                return BadRequest("read debug");
                throw;
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromForm] ClassicMusicBL classicMusicBL)
        {
            try
            {
                await _partyService.UpdateAsync(classicMusicBL);    //ToDo  validate
                return Ok();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(this.GetType() + ex.Message);   //ToDo  delete after
                return BadRequest("read debug");
            }
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return NoContent();
            //RedirectToAction("Delete", "ArtEventsController", id);
        }
    }
}
