using System.Collections.Generic;

namespace App.StarShips
{
    public class StarShipDTO
    {
        public string NextPage { get; set; }
        public IList<StarShipItemDTO> StarShipItemDTO { get; set; }
        
        public StarShipDTO()
        {
            StarShipItemDTO = new List<StarShipItemDTO>();
        }
    }
}