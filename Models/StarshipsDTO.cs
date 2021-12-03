using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace IntergalacticAirways.Models
{
    public class StarshipsDTO
    {
        public string Name { get; set; }
        public string Model { get; set; }

        [JsonProperty(PropertyName = "starship_class")]
        public string StarshipClass { get; set; }
        public string Manufacturer { get; set; }
        public string CostInCredits { get; set; }
        public string Length { get; set; }
        public string Crew { get; set; }
        public string Passengers { get; set; }
        public string MaxAtmospheringSpee { get; set; }
        public double HyperdriveRating { get; set; }
        public string MGLT { get; set; }
        public int CargoCapacity { get; set; }
        public string Consumables { get; set; }
        //public string Pilots { get; set; }
        public List<string> Pilots { get; set; }
        public List<Pilot> PilotDetails { get; set; }
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }
    }
}
