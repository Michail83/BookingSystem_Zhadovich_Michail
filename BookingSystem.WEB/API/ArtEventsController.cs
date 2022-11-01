using BookingSystem.BusinessLogic.BusinesLogicModels;
using BookingSystem.BusinessLogic.Interfaces;
using BookingSystem.WEB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;

namespace BookingSystem.WEB.API
{
    
    public class ArtEventsController : BaseCRUDController<ArtEventBL, IncomingBaseCreateArtEventViewModel>
    {
        public ArtEventsController(IBusinessLayerCRUDServiceAsync<ArtEventBL> CRUDService, IMapper mapper) : base(CRUDService, mapper)
        {
        }

        [HttpGet]
        public override async Task<ActionResult> Get([FromQuery] PagesState pageStatus = null)
        {
            try
            {                
                var QueryResult = await _CRUDService.GetAllAsync(pageStatus);

                List<ArtEventViewModel> response = new();
                foreach (var item in QueryResult)
                {
                    response.Add(_mapper.Map<ArtEventViewModel>(item));    //  add method to mapper???
                }
                #region AddPageStateInfoToHeader
                var pageInfo = new
                {
                    totalItemsCount = QueryResult.TotalItemsCount,
                    pageSize = QueryResult.PageSize,
                    currentPage = QueryResult.CurrentPage,
                    totalPages = QueryResult.TotalPages,
                    hasNext = QueryResult.HasNext,
                    hasPrevious = QueryResult.HasPrevious
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
        public override async Task<ActionResult> Get(int id)
        {
            try
            {
                return Ok(_mapper.Map<ArtEventViewModel>(await _CRUDService.GetAsync(id)));
            }

            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message); //   ToDo       - delete after
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public override async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _CRUDService.DeleteAsync(id);
                return Ok(id);
            }

            catch (Exception ex)
            {
                Debug.WriteLine(GetType() + ex.Message);//ToDo     change Exception
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public override async Task<IActionResult> Post([FromForm] IncomingBaseCreateArtEventViewModel incomingViewModel)
        {
            return BadRequest();
        }

        [Authorize(Roles = "admin")]
        [HttpPut]
        public override async Task<ActionResult> Put([FromForm] IncomingBaseCreateArtEventViewModel incomingViewModel)
        {
            return BadRequest();
        }
    }
}
