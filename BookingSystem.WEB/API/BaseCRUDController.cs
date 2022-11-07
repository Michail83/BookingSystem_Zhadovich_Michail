using AutoMapper;
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
    [EnableCors("LocalForDevelopmentAllowAll")]
    [Route("api/[controller]")]
    [ApiController]

    public abstract class BaseCRUDController<TypeOfService, TypeofIncoming> : ControllerBase
        where TypeOfService : ArtEventBL where TypeofIncoming : IncomingBaseCreateArtEventViewModel
    {
        internal readonly IBusinessLayerCRUDServiceAsync<TypeOfService> _CRUDService;
        internal readonly IMapper _mapper;

        public BaseCRUDController(IBusinessLayerCRUDServiceAsync<TypeOfService> CRUDService, IMapper mapper)
        {
            _CRUDService = CRUDService;
            _mapper = mapper;
        }

        [HttpGet]
        public virtual  async Task<ActionResult> Get([FromQuery] PagesState pageState = null)
        {
            return BadRequest();
        }

        [HttpGet("{id}")]
        public virtual async Task<ActionResult> Get(int id)
        {
            try
            {
                var result = await _CRUDService.GetAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(this.GetType() + ex.Message);   // ToDo  delete after
                return BadRequest();
            }
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public virtual async Task<IActionResult> Post([FromForm] TypeofIncoming incomingViewModel)
        {
            if (incomingViewModel.Image == null) return BadRequest("Image is required");

            try
            {
                await _CRUDService.CreateAsync(_mapper.Map<TypeOfService>(incomingViewModel));

                return Ok(incomingViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Authorize(Roles = "admin")]
        [HttpPut]
        public virtual async Task<ActionResult> Put([FromForm] TypeofIncoming incomingViewModel)
        {
            try
            {
                await _CRUDService.UpdateAsync(_mapper.Map<TypeOfService>(incomingViewModel));   
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [Authorize(Roles = "admin")]
        [HttpDelete]
        public virtual async Task<ActionResult> Delete([FromQuery] int id)
        {
            return BadRequest();
        }
    }
}
