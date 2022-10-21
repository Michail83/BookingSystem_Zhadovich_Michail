using BookingSystem.BusinessLogic.BusinesLogicModels;
using BookingSystem.BusinessLogic.Interfaces;
using BookingSystem.DataLayer.EntityModels;
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
        IBusinessLayerCRUDServiceAsync<ClassicMusicBL> _classicMusicService;
        IMapper<IncomingClassicMusicCreateViewModel, ClassicMusicBL> _mapper;

        public ClassicMusicController(IBusinessLayerCRUDServiceAsync<ClassicMusicBL> openAirService, IMapper<IncomingClassicMusicCreateViewModel, ClassicMusicBL> mapper)
        {
            _classicMusicService = openAirService;
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
                var result = await _classicMusicService.GetAsync(id);
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
        public async Task<IActionResult> Post([FromForm] IncomingClassicMusicCreateViewModel incoming)
        {
            if (incoming.Image == null) return BadRequest("Image is required");
            try
            {
                await _classicMusicService.CreateAsync(_mapper.Map(incoming));   //ToDO  -  validate parameter,
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
        public async Task<ActionResult> Put([FromForm] IncomingClassicMusicCreateViewModel classicMusicView)
        {
            try
            {
                var classicMusicBL = _mapper.Map(classicMusicView);
                await _classicMusicService.UpdateAsync(classicMusicBL);    //ToDo  validate
                return Ok();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(this.GetType() + ex.Message);   //ToDo  delete after
                return BadRequest("read debug");
            }

        }
        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return BadRequest();
        }
    }
}
