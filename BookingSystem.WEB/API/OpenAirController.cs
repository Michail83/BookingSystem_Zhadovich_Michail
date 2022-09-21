using BookingSystem.BusinessLogic.BusinesLogicModels;
using BookingSystem.BusinessLogic.Interfaces;
using BookingSystem.WEB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Data;
using System.Threading.Tasks;
using System.Drawing;

using System.Drawing.Drawing2D;

using System.Drawing.Imaging;

using BookingSystem.WEB.StaticClasses;

using BookingSystem.DataLayer.EntityFramework.Repository;
using BookingSystem.DataLayer.EntityModels;
using BookingSystem.DataLayer.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace BookingSystem.WEB.API
{
    [Route("openAirs")]
    [ApiController]

    public class OpenAirController : ControllerBase
    {
        IBusinessLayerCRUDServiceAsync<OpenAirBL> _openAirService;
        IMapper<IncomingOpenAirArtEventViewModel, OpenAirBL> _mapper;
        IRepositoryAsync<OpenAir> _repository;

        public OpenAirController(IBusinessLayerCRUDServiceAsync<OpenAirBL> openAirService, IMapper<IncomingOpenAirArtEventViewModel, OpenAirBL> mapper, IRepositoryAsync<OpenAir> repository)
        {
            _openAirService = openAirService;
            _mapper= mapper;
            _repository = repository;
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

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] IncomingOpenAirArtEventViewModel openAirBL)
        {
            try
            {
                var test1 = openAirBL.Image.ToImage();
                var test2 = test1.ResizeImage(640, 480);
                var test3 = test2.ToByteArray();

            }
            catch (Exception ex)
            {

                return BadRequest($"test    ==== {ex.ToString()},  INNER {ex.InnerException?.ToString()}");
            }
            

            try
            {
                await _openAirService.CreateAsync(_mapper.Map(openAirBL));
                
                return Ok(openAirBL);
            }
            catch (Exception ex)
            {
                
                return BadRequest($"exception message {ex.Message}   innerExeption message {ex.InnerException?.Message}");
               
            }
        }

        [Authorize(Roles = "admin")]
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
        [Authorize(Roles = "admin")]
        [HttpDelete]
        public ActionResult Delete([FromQuery] int id)
        {
            return BadRequest();
        }
    }
}
