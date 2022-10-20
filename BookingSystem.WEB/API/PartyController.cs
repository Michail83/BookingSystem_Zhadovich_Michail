using BookingSystem.BusinessLogic.BusinesLogicModels;
using BookingSystem.BusinessLogic.Interfaces;
using BookingSystem.WEB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

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
        IMapper<IncomingPartyCreateViewModel, PartyBL> _mapper;

        public PartyController(IBusinessLayerCRUDServiceAsync<PartyBL> openAirService, IMapper<IncomingPartyCreateViewModel, PartyBL> mapper)
        {
            _partyService = openAirService;
            _mapper = mapper;
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

        
        [Authorize(Roles ="admin")]
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] IncomingPartyCreateViewModel incoming)
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
            }
        }

        [Authorize(Roles = "admin")]
        [HttpPut]
        public async Task<ActionResult> Put([FromForm] PartyBL partyBL)
        {
            throw new NotImplementedException();
            //try
            //{
            //    await _partyService.UpdateAsync(partyBL);    //ToDo  validate
            //    return Ok();
            //}
            //catch (Exception ex)
            //{
            //    System.Diagnostics.Debug.WriteLine(this.GetType() + ex.Message);   //ToDo  delete after
            //    return BadRequest("read debug");
            //}
        }
        [Authorize(Roles = "admin")]
        [HttpDelete]
        public ActionResult Delete([FromQuery] int id)
        {
            return BadRequest();
        }
    }
}
