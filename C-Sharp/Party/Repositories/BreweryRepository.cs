using System.Collections.Generic;
using System.Linq;
using Couchbase;
using Entities;

namespace Repositories
{
    public class BreweryRepository : CouchbaseRepository<Brewery>, IBreweryRepository<Brewery>
    {
        public List<Beer> GetBeers(string breweryName)
        {
            string designDocument = "dev_party";
            string view = "beersByBrewery";

            var beers = new List<Beer>();
            using (var cluster = new Cluster())
            {
                using (var bucket = cluster.OpenBucket(BucketName))
                {
                    var query = bucket.CreateQuery(designDocument, view);                    
                    var result = bucket.Query<Beer>(query);

                    if (result != null && result.TotalRows > 0)
                    {
                        beers.AddRange(from row in result.Rows where row.Value.Brewery == breweryName select row.Value);
                    }
                }
            }

            return beers;
        }
    }
}
