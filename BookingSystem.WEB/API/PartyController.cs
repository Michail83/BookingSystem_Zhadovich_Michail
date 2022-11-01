using AutoMapper;
using BookingSystem.BusinessLogic.BusinesLogicModels;
using BookingSystem.BusinessLogic.Interfaces;
using BookingSystem.WEB.Models;

namespace BookingSystem.WEB.API
{
    public class PartiesController : BaseCRUDController<PartyBL, IncomingPartyCreateViewModel>
    {
        public PartiesController(IBusinessLayerCRUDServiceAsync<PartyBL> CRUDService, IMapper mapper) : base(CRUDService, mapper)
        {
        }
    }
}
