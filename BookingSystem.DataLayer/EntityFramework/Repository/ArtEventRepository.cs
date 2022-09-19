﻿using BookingSystem.DataLayer.EntityModels;
using BookingSystem.DataLayer.Exceptions;
using BookingSystem.DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystem.DataLayer.EntityFramework.Repository
{
    public class ArtEventRepository : IRepositoryAsync<ArtEvent>
    {
        private readonly DbContext _dBContext;
        private readonly DbSet<ArtEvent> _dbSet;

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
        public Task CreateAsync(ArtEvent artEvent)
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
                ArtEvent artEventForRemove = await _dbSet.FirstOrDefaultAsync(artEvent => artEvent.Id == ID);
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
            return _dbSet.AsNoTracking();
        }


        public async Task<ArtEvent> GetAsync(int ID)
        {
            try
            {
                var queryResult = await _dbSet.FirstOrDefaultAsync(x => x.Id == ID);
                if (queryResult == null)
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

        public Task UpdateAsync(ArtEvent artEvent)
        {
            throw new NotImplementedException("Not Supported - ArtEventRepository : IRepositoryAsync<ArtEvent>  == UpdateAsync");

        }
    }
}
