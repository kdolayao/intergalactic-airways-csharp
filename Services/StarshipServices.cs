using IntergalacticAirways.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntergalacticAirways.Services
{
    public class StarshipServices
    {
        public List<StarshipsDTO> GetStarships(HttpClientServices service, string url, int passengerNumber)
        {
            var list = new List<StarshipsDTO>();

            var starships = GetAllStarships(service, url);

            if (starships != null)
            {
                list = starships.Where(x => int.TryParse(x.Passengers, out _) && Int32.Parse(x.Passengers) > 0 && Int32.Parse(x.Passengers) >= passengerNumber).ToList();

                if (list.Count > 0)
                {
                    foreach (var item in list)
                    {
                        AssignPilotDetails(service, item);
                    }
                }
            }

            return list;
        }

        private List<StarshipsDTO> GetAllStarships(HttpClientServices service, string url)
        {
            List<StarshipsDTO> allStarShips = new List<StarshipsDTO>();

            var model = service.GetStarships(url).Result;
            allStarShips.AddRange(model.Results);

            while (!string.IsNullOrWhiteSpace(model.Next))
            {
                model = service.GetStarships(model.Next).Result;
                allStarShips.AddRange(model.Results);
            }

            return allStarShips;
        }

        private void AssignPilotDetails(HttpClientServices service, StarshipsDTO item)
        {
            List<Pilot> pilotList = new List<Pilot>();

            foreach (var pilot in item.Pilots)
            {
                var pilotDetails = service.GetPilot(pilot).Result;

                pilotList.Add(pilotDetails);
            }

            item.PilotDetails = pilotList;
        }

    }
}
