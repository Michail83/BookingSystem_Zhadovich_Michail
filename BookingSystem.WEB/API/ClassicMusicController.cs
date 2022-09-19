using BookingSystem.BusinessLogic.BusinesLogicModels;
using BookingSystem.BusinessLogic.Interfaces;
using BookingSystem.WEB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Data;
using System.Threading.Tasks;

namespace BookingSystem.WEB.API
{
    [Route("ClassicMusic")]
    [ApiController]
    [EnableCors("LocalForDevelopmentAllowAll")]
    public class ClassicMusicController : ControllerBase
    {
        IBusinessLayerCRUDServiceAsync<ClassicMusicBL> _partyService;
        IMapper<IncomingClassicMusicArtEventViewModel, ClassicMusicBL> _mapper;

        public ClassicMusicController(IBusinessLayerCRUDServiceAsync<ClassicMusicBL> openAirService, IMapper<IncomingClassicMusicArtEventViewModel, ClassicMusicBL> mapper)
        {
            _partyService = openAirService;
            _mapper=mapper;
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

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] IncomingClassicMusicArtEventViewModel incoming)
        {
            try
            {
                await _partyService.CreateAsync(_mapper.Map(incoming));   //ToDO  -  validate parameter,
                return Ok();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(this.GetType() + ex.Message);   //ToDo  delete after
                return BadRequest("read debug");
                throw;
            }
        }
        [Authorize(Roles = "admin")]
        [HttpPut]
        public async Task<ActionResult> Put([FromForm] ClassicMusicBL classicMusicBL)
        {
            throw new NotImplementedException();
           
        }
        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return BadRequest();
        }
    }
}
