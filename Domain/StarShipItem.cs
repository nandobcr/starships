using Newtonsoft.Json;
using System.Collections.Generic;

namespace Domain
{
    public class StarShipItem
    {
        public string Name { get; set; }
        
        public string Model { get; set; }
        
        public string Manufacturer { get; set; }
        
        [JsonProperty("cost_in_credits")]
        public string CostInCredits { get; set; }
        
        public double Length { get; set; }
        
        [JsonProperty("max_atmosphering_speed")]
        public string MaxAtmospheringSpeed { get; set; }
        
        public string Crew { get; set; }
        
        [JsonProperty("cargo_capacity")]
        public string CargoCapacity { get; set; }
        
        public string Consumables { get; set; }
        
        [JsonProperty("hyperdrive_rating")]
        public string HyperDriveRating { get; set; }
        
        public string Mglt { get; set; }
        
        [JsonProperty("starship_class")]
        public string StarshipClass { get; set; }
        
        public IEnumerable<string> Pilots { get; set; }
        
        public IEnumerable<string> Films { get; set; }
        
        public string Created { get; set; }
        
        public string Edited { get; set; }
        
        public string Url { get; set; }
    }
}