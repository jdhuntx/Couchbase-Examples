using System.Collections.Generic;
using Entities;
using NUnit.Framework;
using Repositories;
using Services;

namespace Tests.ServiceTests
{
    [TestFixture]
    public class BreweryTests
    {
        [SetUp]
        public void Setup()
        {
            IBreweryRepository<Brewery> repository = new BreweryRepository();
            var breweryService = new BreweryService(repository);

            // Insert single brewery
            var brewery = new Brewery
            {
                Name = "Duff",
                Description = "Beers for the working class hero",
                Location = new Location
                {
                    Address = "Beer Avenue",
                    City = "Springfield",
                    State = "Ohio",
                    ZipCode = "45501",
                    Country = "United States"
                }
            };
            breweryService.InsertBrewery(brewery);

            // Insert multiple breweries
            var breweries = new List<Brewery>();
            var brewery1 = new Brewery
            {
                Name = "Flying Pig Brewery",
                Description = "Somewhere in all of us lies an athlete who wants to drink a beer",
                Location = new Location
                {
                    Address = "644 Linn Street",
                    City = "Cincinnati",
                    State = "Ohio",
                    ZipCode = "45203",
                    Country = "United States"
                }
            };
            breweries.Add(brewery1);

            var brewery2 = new Brewery
            {
                Name = "Bluth Brews",
                Description = "Having a little family drama?  Try one of our brews.",
                Location = new Location
                {
                    Address = "123 Easy Street",
                    City = "Newport Beach",
                    State = "California",
                    ZipCode = "92660",
                    Country = "United States"
                }
            };
            breweries.Add(brewery2);

            breweryService.InsertBreweries(breweries);
        }

        [Test]
        public void BreweryService_ValidBreweryRequested_ReturnBrewery()
        {
            string breweryName = "Bluth Brews";

            IBreweryRepository<Brewery> repository = new BreweryRepository();
            var breweryService = new BreweryService(repository);
            
            var brewery = breweryService.GetBrewery(breweryName);
            Assert.IsNotNull(brewery);
        }

        [Test]
        public void BreweryService_InvalidBreweryRequested_ReturnNull()
        {
            IBreweryRepository<Brewery> repository = new BreweryRepository();
            var breweryService = new BreweryService(repository);

            string breweryName = "Carrie Nation Brewing Company";

            var brewery = breweryService.GetBrewery(breweryName);
            Assert.IsNull(brewery);
        }

        [Test]
        public void BreweryService_ValidBreweryBeersRequested_ReturnBeers()
        {
            IBreweryRepository<Brewery> repository = new BreweryRepository();
            var breweryService = new BreweryService(repository);

            string breweryName = "Bluth Brews";

            var beers = breweryService.GetBeers(breweryName);
            Assert.IsNotNull(beers);
            Assert.IsTrue(beers.Count == 2);
        }

        [Test]
        public void BreweryService_RemoveExistingBrewery_DeleteBrewery()
        {
            string breweryName = "Zeppelin Brews";

            IBreweryRepository<Brewery> repository = new BreweryRepository();
            var breweryService = new BreweryService(repository);

            var newBrewery = new Brewery
            {
                Name = breweryName,
                Description = "Beers for the guitar heros",
                Location = new Location
                {
                    Address = "Beer Avenue",
                    City = "London",                                        
                    Country = "United Kingdom"
                }
            };
            breweryService.InsertBrewery(newBrewery);

            var brewery = breweryService.GetBrewery(breweryName);
            Assert.IsNotNull(brewery);

            breweryService.RemoveBrewery(breweryName);
            brewery = breweryService.GetBrewery(breweryName);
            Assert.IsNull(brewery);
        }
    }
}
