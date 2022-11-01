using BookingSystem.BusinessLogic.BusinesLogicModels;
using BookingSystem.BusinessLogic.Interfaces;
using BookingSystem.DataLayer.EntityModels;
using BookingSystem.DataLayer.Interfaces;
using AutoMapper;

namespace BookingSystem.BusinessLogic.Services.CRUDServices
{
    public class PartyCRUDService : BaseGenericCRUDArtEventService<PartyBL, Party>
    {
        public PartyCRUDService(IRepositoryAsync<Party> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
