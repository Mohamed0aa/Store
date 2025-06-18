using Domain.Contract;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using presistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace presistence.Repositories
{
    public class GenericRepo<TEntity, TKey> : IGenericRepo<TEntity, TKey> where TEntity : BaseEntitiy<TKey>
    {
        private readonly StoreDbContext _context;
        public GenericRepo( StoreDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync(bool TrackingChange= false)
        {
            if(typeof(TEntity)==typeof(Product))
            {
                return TrackingChange ?
               await _context.Products.Include(p=>p.ProductBrand).Include(p=>p.ProductType).ToListAsync() as IEnumerable<TEntity>
               : await _context.Products.Include(p => p.ProductBrand).Include(p => p.ProductType).AsNoTracking().ToListAsync() as IEnumerable<TEntity>;
            }
            return TrackingChange ?
               await _context.Set<TEntity>().ToListAsync()
               :await _context.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(TKey id)
        {
            if (typeof(TEntity) == typeof(Product))
            {
                return await _context.Products.Include(p=>p.ProductBrand).Include(p=>p.ProductType).FirstOrDefaultAsync(p=>p.Id== id as int?  ) as TEntity ;
            }
            return await _context.Products.FindAsync(id) as TEntity;
        }

        public async Task AddAsync(TEntity entity)
        {
           await _context.Set<TEntity>().AddAsync(entity);
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }
        public async Task<int> SavechangeAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
