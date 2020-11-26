using Domain;
using RestSharp;
using System.Net;
using Newtonsoft.Json;
using Infra.Exceptions;

namespace App.StarShips
{
    public class StarShipFacade : IStarShip
    {
        public StarShip GetStarShips(string url)
        {
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);

            IRestResponse response = client.Execute(request);
            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                return JsonConvert.DeserializeObject<StarShip>(response.Content);
            }
            else
            {
                throw new StarShipsNullException("StarShips not found.");
            }
        }
    }
}