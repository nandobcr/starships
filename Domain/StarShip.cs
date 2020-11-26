using Newtonsoft.Json;
using System.Collections.Generic;

namespace Domain
{
    public class StarShip
    {
        public int Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        [JsonProperty("results")]
        public IEnumerable<StarShipItem> StarShipItems { get; set; }
    }
}