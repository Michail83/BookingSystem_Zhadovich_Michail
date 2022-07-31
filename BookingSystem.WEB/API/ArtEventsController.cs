using BookingSystem.BusinessLogic.BusinesLogicModels;
using BookingSystem.BusinessLogic.Interfaces;
using BookingSystem.WEB.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;
using System.Threading.Tasks;

namespace BookingSystem.WEB.API
{
    [Route("ArtEvents")]
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
       
        [HttpGet]
        public async Task<ActionResult<ArtEventViewModel>> Get([FromQuery] PagesState pageStatus = null)
        {
            try
            {
                PagesState _artEventBLPagesStatus = pageStatus ?? new PagesState();
                var QueryResult = await _artEventBLService.GetAllAsync(_artEventBLPagesStatus);

                List<ArtEventViewModel> response = new();
                foreach (var item in QueryResult)
                {
                    response.Add(_mapperToViewModel.Map(item));    //  add method to mapper???
                }
                #region AddPageStateInfoToHeader
                var pageInfo = new
                {
                    totalItemsCount=  QueryResult.TotalItemsCount,
                    pageSize=QueryResult.PageSize,
                    currentPage=QueryResult.CurrentPage,
                    totalPages=QueryResult.TotalPages,
                    hasNext=QueryResult.HasNext,
                    hasPrevious=QueryResult.HasPrevious
                };
                HttpContext.Response.Headers.Add("PageStateInfo", JsonSerializer.Serialize(pageInfo));
                #endregion AddPageStateInfoToHeader
                return Ok(response);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(GetType() + "      " + ex.Message);
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ArtEventViewModel>> Get(int id)
        {
            try
            {
                return Ok(_mapperToViewModel.Map(await _artEventBLService.GetAsync(id)));
            }
            
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message); //   ToDo       - delete after
                return BadRequest(ex.Message);
            }
        }
       
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _artEventBLService.DeleteAsync(id);
                return Ok(id);
            }
            
            catch (Exception ex)
            {
                Debug.WriteLine(GetType() + ex.Message);//ToDo     change Exception
                return BadRequest(ex.Message);
            }
        }
    }
}
