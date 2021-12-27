using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BookingSystem.DataLayer;
using BookingSystem.BusinessLogic.Interfaces;
using BookingSystem.BusinessLogic.Services;
using BookingSystem.DataLayer.EntityModels;
using BookingSystem.BusinessLogic.BusinesLogicModels;
using BookingSystem.DataLayer.EntityFramework.Repository;
using Microsoft.EntityFrameworkCore;
using BookingSystem.WEB.Models;
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.AspNetCore.Cors;
using System.Diagnostics;
using BookingSystem.DataLayer.Exceptions;


namespace BookingSystem.WEB.API
{
    [Route("apiArtEvents")]
    [ApiController]
    [EnableCors("LocalForDevelopmentAllowAll")]
    public class ArtEventsController : ControllerBase
    {
        IBusinessLayerCRUDServiceAsync<ArtEventBL> _artEventBLService;
        IMapper<ArtEventBL, ArtEventViewModel> _mapperToViewModel;
        public ArtEventsController(IBusinessLayerCRUDServiceAsync<ArtEventBL> artEventBLService, IMapper<ArtEventBL, ArtEventViewModel> mapperToViewModel)
        {
            _artEventBLService = artEventBLService;
            _mapperToViewModel = mapperToViewModel;
           
        }
       
        [Route("GetAllArtEvents")]
        [HttpGet]
        public async Task<ActionResult<ArtEventViewModel>> Get([FromQuery] PagesState pageStatus = null)
        {
            PagesState _artEventBLPagesStatus = pageStatus ?? new PagesState();
            var QueryResult = await _artEventBLService.GetAllAsync(_artEventBLPagesStatus);
            List<ArtEventViewModel> response = new();

            foreach (var item in QueryResult)
            {
                response.Add(_mapperToViewModel.Map(item));    //  add method to mapper???
            }
            #region maybeEject
            var pageInfo = new
            {
                QueryResult.TotalItemsCount,
                QueryResult.PageSize,
                QueryResult.CurrentPage,
                QueryResult.TotalPages,
                QueryResult.HasNext,
                QueryResult.HasPrevious
            };
            HttpContext.Response.Headers.Add("PageStateInfo", JsonSerializer.Serialize(pageInfo));
            #endregion maybeEject
            return Ok(response);
        }        
       
        [HttpGet]     
        public async Task<ActionResult<ArtEventViewModel>> Get(int id)
        {
            try
            {
                return Ok(_mapperToViewModel.Map(await _artEventBLService.GetAsync(id)));
            }
            catch (EFCoreDbException ex)
            {
                Debug.WriteLine(ex.Message); //   ToDo       - delete after 
                return BadRequest();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message); //   ToDo       - delete after 
                return BadRequest();
            }            
        }        

        [HttpDelete]
        public async Task<ActionResult> Delete([FromQuery]int id)
        {
            try
            {
                await _artEventBLService.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);//ToDo     change Exception
                return NotFound();    
            }
            return Ok();
        }
    }
}
