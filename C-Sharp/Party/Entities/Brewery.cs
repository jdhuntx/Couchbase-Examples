using System;
using Newtonsoft.Json;

namespace Entities
{
    public class Brewery : Entity
    {
        private static string _documentType = "brewery";

        public override string Id
        {
            get { return GetKey(Name); }
        }

        public override string DocumentType
        {
            get { return _documentType; }
        }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        public static string GetKey(string name)
        {
            return _documentType + "-" + name.Replace(" ", "_");
        }
    }
}
