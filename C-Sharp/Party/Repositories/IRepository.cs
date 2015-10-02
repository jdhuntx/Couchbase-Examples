using System.Collections.Generic;
using Entities;

namespace Repositories
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        void Insert(TEntity entity);
        void Insert(IEnumerable<TEntity> entities);
        TEntity Get(string key);
        void Delete(TEntity entity);
        void Delete(string key);
        void Delete(List<string> keys);
    }
}
