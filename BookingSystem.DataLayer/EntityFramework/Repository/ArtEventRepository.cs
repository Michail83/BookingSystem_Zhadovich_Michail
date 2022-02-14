using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingSystem.DataLayer.Interfaces;
using BookingSystem.DataLayer.EntityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Data.SqlClient;
using BookingSystem.DataLayer.Exceptions;

namespace BookingSystem.DataLayer.EntityFramework.Repository
{
    public class ArtEventRepository : IRepositoryAsync<ArtEvent>
    {
        private DbContext _dBContext;
        private DbSet<ArtEvent> _dbSet;

        public ArtEventRepository(BookingSystemDBContext dBContext)
        {
            _dBContext = dBContext;
            _dbSet = _dBContext.Set<ArtEvent>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="artEvent"></param>
        /// <returns></returns>
        /// <exception cref="EFCoreDbException"></exception>
        public  Task CreateAsync(ArtEvent artEvent)
        {
             throw new NotImplementedException("Not supported  -  ArtEventRepository : IRepositoryAsync<ArtEvent>==  CreateAsync ");
            //try
            //{
            //    await _dbSet.AddAsync(artEvent);

            //}
            //catch (SqlException sqlEx)
            //{
            //    throw new EFCoreDbException(sqlEx.Message);                
            //}

        }
        #region SummuryDeleteAsync
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        /// <exception cref="EventNotFoundException"></exception>
        /// <exception cref="EFCoreDbException"></exception>
        #endregion SummuryDeleteAsync
        public async Task DeleteAsync(int ID)
        {            
            try
            {
                ArtEvent artEventForRemove = await _dbSet.FirstOrDefaultAsync(artEvent =>artEvent.Id == ID);
                if (artEventForRemove == null)
                {
                    throw new EventNotFoundException("Событие не найдено");
                }

                _dbSet.Remove(artEventForRemove);
                await _dBContext.SaveChangesAsync();
            }
            catch (SqlException sqlEx)
            {

                throw new EFCoreDbException(sqlEx.Message);
                // реализовать исключение потому что дольше не надо знать sqlException
            }
        }

        public IQueryable<ArtEvent> GetAll()
        {
            return  _dbSet.AsNoTracking();
        }

        /// <summary>
        /// Is it meaningless?   Check
        /// </summary>
        /// <param name="ID"></param>
        /// <returns>ArtEvent </returns>
        /// <exception cref="NullReferenceException"></exception>
        /// <exception cref="EFCoreDbException"> All  SqlException  </exception>
        public async Task<ArtEvent> GetAsync(int ID)
        {
            try
            {
                var queryResult = await _dbSet.FirstOrDefaultAsync(x => x.Id == ID);
                if (queryResult==null)
                {
                    throw new EventNotFoundException("Событие не найдено");
                }
                return queryResult;

            }
            //catch (ArgumentNullException Ex)     //!!!!!!!!    Ловить в контроллере?!?
            //{

            //    throw new EFCoreDbException(Ex.Message+ "Not Found");
            //}
            catch (SqlException sqlEx)
            {                
                throw new EFCoreDbException(sqlEx.Message); 
            }           
        }

        public  Task UpdateAsync(ArtEvent artEvent)
        {
             throw new NotImplementedException("Not Supported - ArtEventRepository : IRepositoryAsync<ArtEvent>  == UpdateAsync");

        }
    }
}
