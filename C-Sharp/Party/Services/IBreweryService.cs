using System.Collections.Generic;
using Entities;

namespace Services
{
    public interface IBreweryService
    {
        void InsertBrewery(Brewery brewery);
        void InsertBreweries(List<Brewery> breweries);
        Brewery GetBrewery(string name);
        List<Beer> GetBeers(string breweryName);
        void RemoveBrewery(string name);
    }
}
