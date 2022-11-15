using BookingSystem.BusinessLogic.BusinesLogicModels;
using BookingSystem.BusinessLogic.Interfaces;
using BookingSystem.DataLayer.EntityModels;
using BookingSystem.DataLayer.Interfaces;
using BookingSystem.WEB.Models;
using BookingSystem.WEB.StaticClasses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using AutoMapper;

namespace BookingSystem.WEB.API
{
    public class OpenAirsController : BaseCRUDController<OpenAirBL, IncomingOpenAirCreateViewModel>
    {
        public OpenAirsController(IBusinessLayerCRUDServiceAsync<OpenAirBL> CRUDService, IMapper mapper) : base(CRUDService, mapper)
        {
        }
    }
}
