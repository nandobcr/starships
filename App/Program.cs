using System;
using App.StarShips;
using Infra.Exceptions;

namespace App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Inform the distance in mega lights:");
            string distance = Console.ReadLine();
            int countPages = 1;

            string url = "http://swapi.dev/api/starships/";
            var starShipFacade = new StarShipFacade();
            var starShipService = new StarShipService(starShipFacade);

            try
            {
                do
                {
                    StarShipDTO starShipDTO = starShipService.GetStopsRequired(distance, url);
                    BuildHeader(countPages);
                    ShowStarShips(starShipDTO);
                    url = starShipDTO.NextPage;
                    countPages++;

                } while (!string.IsNullOrEmpty(url));                
            }
            catch (DistanceInvalidException ex)
            {
                Console.WriteLine(ex.Message);                
            }
            catch (StarShipsNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            ReadKeyToExit();
        }

        private static void BuildHeader(int countPages)
        {
            Console.WriteLine();
            Console.WriteLine(string.Format("Process page {0}", countPages));
            Console.WriteLine("==========================================");
            Console.WriteLine("Name | Stops required");
            Console.WriteLine("==========================================");
        }

        private static void ShowStarShips(StarShipDTO starShipDTO)
        {
            foreach (var starShipItemDTO in starShipDTO.StarShipItemDTO)
            {
                string stopsRequired = (starShipItemDTO.StopsRequired > 0) 
                    ? starShipItemDTO.StopsRequired.ToString()
                    : "unknow";

                Console.WriteLine(string.Format("{0} | {1}", starShipItemDTO.Name, stopsRequired));
            }
        }

        private static void ReadKeyToExit()
        {
            ConsoleKeyInfo keyInfo;
            Console.WriteLine();
            Console.WriteLine("Press ESC to exit...");

            while (true)
            {
                keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    break;
                }
            }
        }
    }
}
