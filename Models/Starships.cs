using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace IntergalacticAirways.Models
{
    public class Starships
    {
        public int Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public List<StarshipsDTO> Results { get; set; }
    }
}
