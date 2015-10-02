using System.Collections.Generic;
using Entities;
using Repositories;

namespace Services
{
    public class BeerService : IBeerService
    {
        private readonly IRepository<Beer> _repository;

        public BeerService(IRepository<Beer> repository)
        {
            _repository = repository;
        }

        public void InsertBeer(Beer beer)
        {
            _repository.Insert(beer);
        }

        public void InsertBeers(List<Beer> beers)
        {
            _repository.Insert(beers);
        }

        public Beer GetBeer(string brewery, string name)
        {
            string key = Beer.GetKey(brewery, name);
            return _repository.Get(key);
        }

        public void RemoveBeer(string brewery, string name)
        {
            string key = Beer.GetKey(brewery, name);
            _repository.Delete(key);
        }
    }
}
