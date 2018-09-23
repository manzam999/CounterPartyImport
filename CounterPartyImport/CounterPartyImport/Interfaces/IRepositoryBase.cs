using CounterPartyImport.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CounterPartyImport.Interfaces
{
    public interface IRepositoryBase<TEntity> where TEntity : EntityBase
    {
        IEnumerable<TEntity> GetAll(int? page = null);
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> expression);
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(int id, TEntity entity);
        Task DeleteAsync(int id);
        void BulkInsert(List<TEntity> entities);
    }
}