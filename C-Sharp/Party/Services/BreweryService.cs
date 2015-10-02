using System.Collections.Generic;
using Entities;
using Repositories;

namespace Services
{
    public class BreweryService : IBreweryService
    {
        private readonly IBreweryRepository<Brewery> _repository;

        public BreweryService(IBreweryRepository<Brewery> repository)
        {
            _repository = repository;
        }

        public void InsertBrewery(Brewery brewery)
        {
            _repository.Insert(brewery);
        }

        public void InsertBreweries(List<Brewery> breweries)
        {
            _repository.Insert(breweries);
        }

        public Brewery GetBrewery(string name)
        {
            string key = Brewery.GetKey(name);
            return _repository.Get(key);
        }

        public List<Beer> GetBeers(string breweryName)
        {
            return _repository.GetBeers(breweryName);
        }

        public void RemoveBrewery(string name)
        {
            string key = Brewery.GetKey(name);
            _repository.Delete(key);
        }
    }
}
