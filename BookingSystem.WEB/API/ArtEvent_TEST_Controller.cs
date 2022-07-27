using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BookingSystem.DataLayer;
using BookingSystem.BusinessLogic.Interfaces;
using BookingSystem.BusinessLogic.Services;
using BookingSystem.DataLayer.EntityModels;
using BookingSystem.BusinessLogic.BusinesLogicModels;
using BookingSystem.DataLayer.EntityFramework.Repository;
using Microsoft.EntityFrameworkCore;
using BookingSystem.WEB.Models;
using System.Diagnostics;

namespace BookingSystem.WEB.API
{
    [Route("TEST")]
    [ApiController]
    public class ArtEvent_TEST_Controller : ControllerBase
    {
        IDataService_TEST<ArtEventBL> _artEventBLService;
        public ArtEvent_TEST_Controller(IDataService_TEST<ArtEventBL> artEventBLService)
        {
            _artEventBLService = artEventBLService;
        }
        // GET: api/<ArtEvent_TEST_Controller>
        [Route("GetAll")]
        [HttpGet]
        public IEnumerable<ArtEventBL> Get([FromQuery] Test_Class_forBinding pageStatus = null)
        {
            Debug.WriteLine(pageStatus.ToString());
            return _artEventBLService.GetAll(new PagesState());
        }

        [Route("GetAllWithout")]
        [HttpGet]
        public IEnumerable<ArtEventBL> Get()
        {
            return _artEventBLService.GetAll(new PagesState());
        }

        // GET api/<ArtEvent_TEST_Controller>/5
        [Route("Get")]
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ArtEvent_TEST_Controller>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ArtEvent_TEST_Controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ArtEvent_TEST_Controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
