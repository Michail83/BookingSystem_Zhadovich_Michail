using BookingSystem.BusinessLogic.BusinesLogicModels;
using BookingSystem.BusinessLogic.Interfaces;
using BookingSystem.DataLayer.EntityModels;
using BookingSystem.DataLayer.Interfaces;
using AutoMapper;

namespace BookingSystem.BusinessLogic.Services.CRUDServices
{
    public class OpenAirCRUDService : BaseGenericCRUDArtEventService<OpenAirBL, OpenAir>
    {
        public OpenAirCRUDService(IRepositoryAsync<OpenAir> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
