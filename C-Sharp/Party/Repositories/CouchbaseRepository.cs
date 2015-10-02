using System.Collections.Generic;
using System.Linq;
using Couchbase;
using Entities;

namespace Repositories
{
    public class CouchbaseRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly string BucketName = "Party";

        public void Insert(TEntity entity)
        {
            Insert(new List<TEntity> { entity });
        }

        public void Insert(IEnumerable<TEntity> entities)
        {
            using (var cluster = new Cluster())
            {
                using (var bucket = cluster.OpenBucket(BucketName))
                {
                    var items = entities.ToDictionary<TEntity, string, dynamic>(entity => entity.Id, entity => entity);
                    bucket.Upsert(items);
                }
            }
        }

        TEntity IRepository<TEntity>.Get(string key)
        {
            using (var cluster = new Cluster())
            {
                using (var bucket = cluster.OpenBucket(BucketName))
                {
                    var document = bucket.GetDocument<TEntity>(key);
                    return document.Content;
                }
            }
        }

        public void Delete(TEntity entity)
        {
            Delete(new List<string> { entity.Id });
        }

        public void Delete(string id)
        {
            Delete(new List<string> {id});
        }

        public void Delete(List<string> ids)
        {
            using (var cluster = new Cluster())
            {
                using (var bucket = cluster.OpenBucket(BucketName))
                {
                    bucket.Remove(ids);                    
                }
            }
        }
    }
}