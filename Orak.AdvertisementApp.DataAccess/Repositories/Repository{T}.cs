using Microsoft.EntityFrameworkCore;
using Orak.AdvertisementApp.Common.Enums;
using Orak.AdvertisementApp.DataAccess.Contexts;
using Orak.AdvertisementApp.DataAccess.İnterfaces;
using Orak.AdvertisementApp.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Orak.AdvertisementApp.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AdvertisementContext _context;

        public Repository(AdvertisementContext context) 
        {
            _context = context;
        }
        // bütün veriyi getirme
        // bütün veriyi sıralayarak getirme
        // bütün veriyi filter getirme
        // asNoTracking()
        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }
        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter)
        {
            return await _context.Set<T>().Where(filter).AsNoTracking().ToListAsync();
        }
        // Veriyi sıralayarak getirmek
        public async Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, TKey>> selector, OrderByType orderByType = OrderByType.ASC)
        {
            // Normal olarak varsayılan default değerini Azalan sıralama manasına gelen desc oalrak belirttim. 
            return orderByType == OrderByType.ASC ? await _context.Set<T>().AsNoTracking().OrderBy(selector).ToListAsync() :
                await _context.Set<T>().AsNoTracking().OrderByDescending(selector).ToListAsync();
        }
        // hem sıralamalı hemde filterlı veri çekme işlemi
        public async Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, bool>> filter, Expression<Func<T, TKey>> selector, OrderByType orderByType = OrderByType.DESC)
        {

            return orderByType == OrderByType.ASC ? await _context.Set<T>().Where(filter).AsNoTracking().OrderBy(selector).ToListAsync()
                : await _context.Set<T>().Where(filter).AsNoTracking().OrderByDescending(selector).ToListAsync();

        }
        public async Task<T> FindAsync(object id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        // Tracking varsa veya yoksa ona göre bir veri getirme operasyonu
        public async Task<T> GetByFilterAsync(Expression<Func<T,bool>> filter, bool asNoTracking = false)
        {
        
            return !asNoTracking ? await _context.Set<T>().AsNoTracking().SingleOrDefaultAsync(filter) 
                : await _context.Set<T>().SingleOrDefaultAsync(filter);
        }
        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
        public IQueryable GetQuery()
        {
            return _context.Set<T>().AsQueryable();
        }
        public async Task CreateAsync(T entity)
        {
            await _context.AddAsync(entity);
        }
        public void Update(T entity, T unchanged)
        {
        
            _context.Entry(unchanged).CurrentValues.SetValues(entity);
        }
    }

}
