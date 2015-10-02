using Newtonsoft.Json;

namespace Entities
{
    public class Entity
    {
        [JsonIgnore]
        public virtual string Id { get; private set; }

        [JsonProperty("documenttype")]
        public virtual string DocumentType { get; private set; }        
    }
}
