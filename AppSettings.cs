using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntergalacticAirways
{
    public class AppSettings
    {
        public StarWarsApi StarWarsApi { get; set; }
    }

    public class StarWarsApi
    {
        public string Url { get; set; }
        public Endpoints Endpoints { get; set; }
    }

    public class Endpoints
    {
        public string Starships { get; set; }
        public string People { get; set; }
    }
}
