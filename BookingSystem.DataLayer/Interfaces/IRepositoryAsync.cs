using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingSystem.DataLayer.EntityModels;

namespace BookingSystem.DataLayer.Interfaces
{
    public interface IRepositoryAsync<T> where T : ArtEvent
    {
        public IQueryable<T> GetAll();
        public Task<T> GetAsync(int ID);
        public Task UpdateAsync(T item);
        public Task CreateAsync(T item);
        public Task DeleteAsync(int ID);


    }
}
