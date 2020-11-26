using Infra;
using Domain;
using Infra.Exceptions;
using Domain.Calculation;
using Infra.ExtensionsMethods;
using System.Collections.Generic;

namespace App.StarShips
{
    public class StarShipService
    {
        private readonly IStarShip starShipFacade;
        private readonly IDayConverter DayConverter;
        private readonly CalculationStops calculationStops;
        
        public StarShipService(IStarShip starShipFacade)
        {
            this.starShipFacade = starShipFacade;
            this.DayConverter = new DayConverter();
            this.calculationStops = new CalculationStops();
        }

        public StarShipDTO GetStopsRequired(string distanceMgltText, string url)
        {
            int distanceMglt = ConvertDistance(distanceMgltText);
            StarShip starShip = this.starShipFacade.GetStarShips(url);
            IEnumerable<StarShipItem> starShipItems = starShip.StarShipItems;

            var starShipDTO = new StarShipDTO();
            starShipDTO.NextPage = starShip.Next;

            foreach (var item in starShipItems)
            {
                int daysCount = this.DayConverter.ConvertToDays(item.Consumables);
                int mglt = item.Mglt.ToInt();

                var starShipItemDTO = new StarShipItemDTO();
                starShipItemDTO.Name = item.Name;
                starShipItemDTO.StopsRequired = this.calculationStops
                    .CalculateStops(distanceMglt, mglt, daysCount);

                starShipDTO.StarShipItemDTO.Add(starShipItemDTO);
            } 

            return starShipDTO;
        }

        private int ConvertDistance(string distanceMgltText)
        {
            int distance = distanceMgltText.ToInt();
            if (distance == 0)
            {
                throw new DistanceInvalidException("The distance must be have only numbers.");
            }

            return distance;
        }
    }
}