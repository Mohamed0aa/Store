using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contract
{
    public interface IGenericRepo<TEntity,Tkey>where TEntity : BaseEntitiy<Tkey>
    {
        Task<IEnumerable<TEntity>> GetAllAsync(bool TrackingChange=false);

        Task<TEntity> GetByIdAsync(Tkey id);

        Task AddAsync(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        Task<int> SavechangeAsync();
        //object GetAllAsync();
    }
}
