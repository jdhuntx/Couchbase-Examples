using Newtonsoft.Json;

namespace Entities
{
    public class Beer : Entity
    {
        private static readonly string _documentType = "beer";

        public override string Id
        {
            get { return GetKey(Brewery, Name); }
        }

        public override string DocumentType
        {
            get { return _documentType; }
        }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("abv")]
        public double ABV { get; set; }

        [JsonProperty("brewery")]
        public string Brewery { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        public static string GetKey(string brewery, string name)
        {
            return _documentType + "-" + brewery.Replace(" ", "_") + "-" + name.Replace(" ", "_");
        }
    }
}
