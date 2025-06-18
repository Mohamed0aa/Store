using Domain.Contract;
using Domain.Models;
using presistence.Data;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace presistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreDbContext _context;
        private readonly ConcurrentDictionary<string, object> _repositories;
        public UnitOfWork( StoreDbContext context)
        {
            _context = context;
            _repositories = new ConcurrentDictionary<string, object>();
        }
        public IGenericRepo<TEntity, TKey> GetRepo<TEntity, TKey>() where TEntity : BaseEntitiy<TKey>
        {
          return (IGenericRepo < TEntity, TKey >) _repositories.GetOrAdd(typeof(TEntity).Name,new GenericRepo<TEntity,TKey>(_context));
        }
    }
}
