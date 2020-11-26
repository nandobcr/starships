using Domain;

namespace App.StarShips
{
    public interface IStarShip
    {
        StarShip GetStarShips(string url);
    }
}