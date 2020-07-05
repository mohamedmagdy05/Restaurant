using Microsoft.EntityFrameworkCore;
using Safcsp.Restaurant.Domain.Interfaces;
using Safcsp.Restaurant.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Safcsp.Restaurant.Ioc.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private RestaurantDbContext _ctx;

        public BaseRepository(RestaurantDbContext Context)
        {
            this._ctx = Context;
        }
        public async System.Threading.Tasks.Task<T> Add(T entity)
        {
            _ctx.Set<T>().Add(entity);
            await _ctx.SaveChangesAsync();
            return entity;
        }

        public async System.Threading.Tasks.Task<T> Delete(int id)
        {
            var entity = await _ctx.Set<T>().FindAsync(id);

            if (entity == null)
            {
                return entity;
            }
            _ctx.Set<T>().Remove(entity);
            await _ctx.SaveChangesAsync();
            return entity;

        }

        public async System.Threading.Tasks.Task<T> Get(int id)
        {
            var entity = await _ctx.Set<T>().FindAsync(id);
            return entity;
        }

        public async Task<List<T>> GetAll()
        {
            return await _ctx.Set<T>().ToListAsync();
        }

        public async System.Threading.Tasks.Task<T> Update(T entity)
        {
            _ctx.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _ctx.SaveChangesAsync();
            return entity;
        }

    
    }
}

