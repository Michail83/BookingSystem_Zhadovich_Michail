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
    public class OpenAirRepository : IRepositoryAsync<OpenAir>
    {
        DbContext _dbContext;
        DbSet<OpenAir> _openAirs;
        public OpenAirRepository(BookingSystemDBContext dbContext)
        {
            _dbContext = dbContext;
            _openAirs = _dbContext.Set<OpenAir>();
        }
        public async Task CreateAsync(OpenAir artEvent)
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
            }
        }

        public async Task DeleteAsync(int ID)
        {
            try
            {
                var openAir = await _openAirs.FirstOrDefaultAsync(openAir => openAir.Id == ID);
                _openAirs.Remove(openAir);
                await _dbContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.TargetSite + ex.Message);
            }
        }

        public IQueryable<OpenAir> GetAll()
        {
            try
            {
                return _openAirs.AsNoTracking();
            }
            catch (Exception ex)
            {

                System.Diagnostics.Debug.WriteLine(ex.TargetSite + ex.Message);
                throw;
            }
        }

        public async Task<OpenAir> GetAsync(int ID)
        {
            try
            {
                return await _openAirs.FirstOrDefaultAsync(openAir => openAir.Id == ID);

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.TargetSite + ex.Message);
                throw;
            }
        }

        public async Task UpdateAsync(OpenAir artEvent)
        {
            try
            {
                _openAirs.Update(artEvent);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.TargetSite + ex.Message);
            }
        }
    }
}
