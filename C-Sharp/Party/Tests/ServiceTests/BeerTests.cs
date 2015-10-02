using System.Collections.Generic;
using Entities;
using NUnit.Framework;
using Repositories;
using Services;

namespace Tests.ServiceTests
{
    [TestFixture]
    public class BeerTests
    {
        [SetUp]
        public void Setup()
        {
            IRepository<Beer> repository = new CouchbaseRepository<Beer>();
            var beerService = new BeerService(repository);

            // Insert single beer
            var beer = new Beer
            {
                Name = "Sucking on Wind",
                Description = "A perfect beer to imbibe after a race",
                Brewery = "Flying Pig Brewery",
                ABV = 10
            };

            beerService.InsertBeer(beer);  

            // Insert multiple beers
            var beers = new List<Beer>();
            var beer1 = new Beer
            {
                Name = "Loose Seal",
                Description = "A hoppy IPA from the west coast",
                Brewery = "Bluth Brews",
                ABV = 7
            };
            beers.Add(beer1);

            var beer2 = new Beer
            {
                Name = "Illusions",
                Description = "A deceptively tasty pale ale from the west coast",
                Brewery = "Bluth Brews",
                ABV = 8
            };
            beers.Add(beer2);

            beerService.InsertBeers(beers);
        }

        [Test]
        public void BeerService_ValidBeerRequested_ReturnBeer()
        {
            string brewery = "Flying Pig Brewery";
            string beerName = "Sucking on Wind";

            IRepository<Beer> repository = new CouchbaseRepository<Beer>();
            var beerService = new BeerService(repository);

            var beer = beerService.GetBeer(brewery, beerName);
            Assert.IsNotNull(beer);
        }

        [Test]
        public void BeerService_InvalidBeerRequested_ReturnNull()
        {
            IRepository<Beer> repository = new CouchbaseRepository<Beer>();
            var beerService = new BeerService(repository);

            string brewery = "Kool Aid";
            string name = "Grape";

            var beer = beerService.GetBeer(brewery, name);
            Assert.IsNull(beer);
        }

        [Test]
        public void BeerService_RemoveExistingBeer_DeleteBeer()
        {
            string brewery = "Zeppelin Brews";
            string beerName = "Hammer of the Gods";

            IRepository<Beer> repository = new CouchbaseRepository<Beer>();
            var beerService = new BeerService(repository);

            // Insert single beer
            var newBeer = new Beer
            {
                Name = beerName,
                Description = "This beer packs a wallop!",
                Brewery = brewery,
                ABV = 15
            };
            beerService.InsertBeer(newBeer);  

            var beer = beerService.GetBeer(brewery, beerName);
            Assert.IsNotNull(beer);

            beerService.RemoveBeer(brewery, beerName);
            beer = beerService.GetBeer(brewery, beerName);
            Assert.IsNull(beer);
        }
    }
}
