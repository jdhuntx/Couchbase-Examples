# Couchbase-Examples
These examples showcase how you can use the Couchbase SDK.  In order to run the unit tests, you must have access to Couchbase Server 3.x or greater.  You can install Couchbase locally here: http://www.couchbase.com/nosql-databases/downloads.  

One of the tests uses a view called beersByBrewery, so you will need that view created in the "dev_party" design document with this code to successfully run that test:

function (doc, meta) {
  if (doc.documenttype == 'beer' && doc.brewery) {
    emit(meta.id, doc);
  }
}
