using BookingSystem.DataLayer.EntityModels;
using System.Linq;

namespace BookingSystem.DataLayer.Interfaces
{
    public interface IRepository<T> where T : ArtEvent
    {
        public IQueryable<T> GetAll();
        public T GetAsync(int ID);
        public void Update(T artEvent);
        public void Create(T artEvent);
        public void Delete(int ID);


    }
}
