using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingSystem.DataLayer.EntityModels;
using BookingSystem.DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using BookingSystem.DataLayer.Exceptions;


namespace BookingSystem.DataLayer.EntityFramework.Repository
{
    public class GenericConcreteRepository<T> : IRepositoryAsync<T> where T :ArtEvent
    {
        DbContext _dbContext;
        DbSet<T> _openAirs;
        public GenericConcreteRepository(BookingSystemDBContext dbContext)
        {
            _dbContext = dbContext;
            _openAirs = _dbContext.Set<T>();
        }
        public async Task CreateAsync(T artEvent)
        {
            try
            {
                await _openAirs.AddAsync(artEvent);
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
                var openAir = await _openAirs.FirstOrDefaultAsync(openAir => openAir.Id==ID);
                _openAirs.Remove(openAir);
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
                return _openAirs.AsNoTracking();
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
                var result = await _openAirs.FirstOrDefaultAsync(openAir => openAir.Id == ID);
                if (result==null)
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
                _openAirs.Update(artEvent);
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
