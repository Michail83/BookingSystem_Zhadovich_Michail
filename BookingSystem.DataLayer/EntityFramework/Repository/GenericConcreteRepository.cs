using BookingSystem.DataLayer.EntityModels;
using BookingSystem.DataLayer.Exceptions;
using BookingSystem.DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


namespace BookingSystem.DataLayer.EntityFramework.Repository
{
    public class GenericConcreteRepository<T> : IRepositoryAsync<T> where T : ArtEvent
    {
        DbContext _dbContext;
        DbSet<T> _artEventSet;
        public GenericConcreteRepository(BookingSystemDBContext dbContext)
        {
            _dbContext = dbContext;
            _artEventSet = _dbContext.Set<T>();
        }
        public async Task CreateAsync(T artEvent)
        {
            try
            {
                await _artEventSet.AddAsync(artEvent);
                await _dbContext.SaveChangesAsync();
            }
            catch (SqlException Ex)
            {
                throw new EFCoreDbException(Ex.Message);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task DeleteAsync(int ID)
        {
            try
            {
                var openAir = await _artEventSet.FirstOrDefaultAsync(openAir => openAir.Id == ID);
                _artEventSet.Remove(openAir);
                await _dbContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.TargetSite + ex.Message);
            }
        }

        public IQueryable<T> GetAll()
        {
            try
            {
                return _artEventSet.AsNoTracking();
            }
            catch (Exception ex)
            {

                System.Diagnostics.Debug.WriteLine(GetType() + ex.Message);
                throw;
            }
        }

        public async Task<T> GetAsync(int ID)
        {
            try
            {
                var result = await _artEventSet.FirstOrDefaultAsync(openAir => openAir.Id == ID);
                if (result == null)
                {
                    throw new EventNotFoundException();
                }
                return result;
            }

            catch (ArgumentNullException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.TargetSite + ex.Message);
                throw;
            }
        }

        public async Task UpdateAsync(T artEvent)
        {
            try
            {
                var eventFromBase = await _artEventSet.AsNoTracking().FirstAsync((artEvnt) => artEvnt.Id == artEvent.Id);
                artEvent.Image = artEvent.Image.Length < 1 ? eventFromBase.Image : artEvent.Image;

                _artEventSet.Update(artEvent);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.TargetSite + ex.Message);
                throw;
            }
        }
    }
}
