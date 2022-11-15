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
    public class ClassicMusicController : BaseCRUDController<ClassicMusicBL, IncomingClassicMusicCreateViewModel>
    {
        public ClassicMusicController(IBusinessLayerCRUDServiceAsync<ClassicMusicBL> CRUDService, IMapper mapper) : base(CRUDService, mapper)
        {
        }
    }
}
