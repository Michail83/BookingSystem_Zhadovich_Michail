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

using BookingSystem.WEB.StaticClasses;

using BookingSystem.DataLayer.EntityFramework.Repository;
using BookingSystem.DataLayer.EntityModels;
using BookingSystem.DataLayer.Interfaces;
using System.Collections.Generic;

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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var resultArray = new List<string>();
            resultArray.Add(openAirBL.Image.Length.ToString());

            var imageStage1= openAirBL.Image.ToImage();
            resultArray.Add(imageStage1.PhysicalDimension.ToString());

             var imageStage2 = imageStage1.ResizeImage(new Size(320, 240));
            resultArray.Add(imageStage2.PhysicalDimension.ToString());


            var imageStage3 = imageStage2.ToByteArray();
            resultArray.Add(imageStage3.Length.ToString());


            if (imageStage3.Length==0)
            {
                return BadRequest(resultArray);
            }

            var openAir = new OpenAir 
            {
                Date = openAirBL.Date,
                AmountOfTickets = openAirBL.AmountOfTickets,
                 EventName = openAirBL.EventName,
                 HeadLiner = openAirBL.HeadLiner,
                 Latitude = openAirBL.Latitude,
                 Longitude = openAirBL.Longitude,
                 Place = openAirBL.Place,
                 Image= imageStage3

            };
            try
            {
                await _repository.CreateAsync(openAir);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
           

            return Ok(openAir);



            //try
            //{
            //    await _openAirService.CreateAsync(_mapper.Map(openAirBL)); 

            //    // ToDO  -  validate parameter,
            //    return Ok(openAirBL);
            //}
            //catch (Exception ex)
            //{
            //    System.Diagnostics.Debug.WriteLine(this.GetType() + ex.Message);   // ToDo  delete after
            //    return BadRequest("read debug");
            //    throw;
            //}
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
