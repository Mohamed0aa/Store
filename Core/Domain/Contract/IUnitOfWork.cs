using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contract
{
    public interface IUnitOfWork
    {
        IGenericRepo<TEntity,TKey> GetRepo<TEntity,TKey>()where TEntity : BaseEntitiy<TKey>;
    }
}
