using BookingSystem.BusinessLogic.BusinesLogicModels;
using BookingSystem.BusinessLogic.Interfaces;
using BookingSystem.DataLayer.EntityModels;
using BookingSystem.DataLayer.Interfaces;
using AutoMapper;

namespace BookingSystem.BusinessLogic.Services.CRUDServices
{
    public class ClassicMusicCRUDService : BaseGenericCRUDArtEventService<ClassicMusicBL, ClassicMusic>
    {
        public ClassicMusicCRUDService(IRepositoryAsync<ClassicMusic> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
