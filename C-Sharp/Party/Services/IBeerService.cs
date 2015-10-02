using System.Collections.Generic;
using Entities;

namespace Services
{
    public interface IBeerService
    {
        void InsertBeer(Beer beer);
        void InsertBeers(List<Beer> beers);
        Beer GetBeer(string brewery, string name);
        void RemoveBeer(string brewery, string name);
    }
}
