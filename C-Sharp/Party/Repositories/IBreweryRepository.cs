using System.Collections.Generic;
using Entities;

namespace Repositories
{
    public interface IBreweryRepository<TEntity> : IRepository<TEntity> where TEntity : Brewery
    {
        List<Beer> GetBeers(string breweryName);
    }
}
