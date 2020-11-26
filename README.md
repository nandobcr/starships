StarShips - A simple application capable of organizing your trip... stellar trip :)

Documentantion


This application created using .NET Core, with the objective of calculating the number of necessary stops in a trip through space.

The Star Wars API was used to compose this application, which provides us with the list of starships and their important information for the calculation. See more https://swapi.dev/.


All ships have two pieces of information to perform the calculation, such as: 

*Consumables -> maximum length of time that this starship can provide consumables for its entire crew without having to resupply.
Consumables are informed by periods, such as 10 days, 1 week, 3 months or 5 years, making it necessary that we convert to days.

*MGLT -> The Maximum number of Megalights this starship can travel in a standard hour. A MGLT is a standard unit of distance and has never been defined before within the Star Wars universe.

The formula for stops requires calculation, for each ship is -> DISTANCE TO TRIP / AUTONOMY
Where AUTONOMY is result of -> (CONSUMABLES IN DAYS * 24 HOUR * MGLT).


------------------------------------------------------------------------------
Stops required - greater than 0
------------------------------------------------------------------------------

For example: Distance reported by the traveler -> 1000000 
{
    "name": "Y-wing",
    "model": "BTL Y-wing",
    "manufacturer": "Koensayr Manufacturing",
    "cost_in_credits": "134999",
    "length": "14",
    "max_atmosphering_speed": "1000km",
    "crew": "2",
    "passengers": "0",
    "cargo_capacity": "110",
    "consumables": "1 week",
    "hyperdrive_rating": "1.0",
    "MGLT": "80",
    "starship_class": "assault starfighter",
    "pilots": [],
    "films": [
    "http://swapi.dev/api/films/1/",
    "http://swapi.dev/api/films/2/",
    "http://swapi.dev/api/films/3/"
    ],
    "created": "2014-12-12T11:00:39.817000Z",
    "edited": "2014-12-20T21:23:49.883000Z",
    "url": "http://swapi.dev/api/starships/11/"
} 


Consumables -> 1 week -> 7 days
MGLT -> 80

Autonomy: 7 * 24 * 80 = 13440

Stops required: Distance / Autonomy
Stops required: 1000000 / 13440 
Stops required: 74 (we will use only integer part of number).


------------------------------------------------------------------------------
Stops required - 0
------------------------------------------------------------------------------

Another example where the StarShip don't needs make stop:

Distance reported by the traveler -> 1000000

{
    "name": "Star Destroyer",
    "model": "Imperial I-class Star Destroyer",
    "manufacturer": "Kuat Drive Yards",
    "cost_in_credits": "150000000",
    "length": "1,600",
    "max_atmosphering_speed": "975",
    "crew": "47,060",
    "passengers": "n/a",
    "cargo_capacity": "36000000",
    "consumables": "2 years",
    "hyperdrive_rating": "2.0",
    "MGLT": "60",
    "starship_class": "Star Destroyer",
    "pilots": [],
    "films": [
        "http://swapi.dev/api/films/1/",
        "http://swapi.dev/api/films/2/",
        "http://swapi.dev/api/films/3/"
    ],
    "created": "2014-12-10T15:08:19.848000Z",
    "edited": "2014-12-20T21:23:49.870000Z",
    "url": "http://swapi.dev/api/starships/3/"
}

Consumables -> 2 years -> 730 days
MGLT -> 60

Autonomy: 730 * 24 * 60 = 1051200

Stops required: Distance / Autonomy
Stops required: 1000000 / 1051200 
Stops required: 0 (we will use only integer part of number).


------------------------------------------------------------------------------
Stops required - Unknow
------------------------------------------------------------------------------

Some starships have no all information necessary to calculation, for example:

Distance reported by the traveler -> 1000000

{
    "name": "Droid control ship",
    "model": "Lucrehulk-class Droid Control Ship",
    "manufacturer": "Hoersch-Kessel Drive, Inc.",
    "cost_in_credits": "unknown",
    "length": "3170",
    "max_atmosphering_speed": "n/a",
    "crew": "175",
    "passengers": "139000",
    "cargo_capacity": "4000000000",
    "consumables": "500 days",
    "hyperdrive_rating": "2.0",
    "MGLT": "unknown",
    "starship_class": "Droid control ship",
    "pilots": [],
    "films": [
        "http://swapi.dev/api/films/4/",
        "http://swapi.dev/api/films/5/",
        "http://swapi.dev/api/films/6/"
    ],
    "created": "2014-12-19T17:04:06.323000Z",
    "edited": "2014-12-20T21:23:49.915000Z",
    "url": "http://swapi.dev/api/starships/32/"
}

Consumables -> 500 days
MGLT -> Unknow, so the application considers 0

Autonomy: 7 * 24 * 0 = 0
If AUTONOMY equals 0, the application will not divide by zero ;)
So the stops required must be unknow.



Usage

it's easy to use, just download the code, navigate to the App folder and execute: dotnet run.

Have fun and imagine your next trip in the Star Wars universe.



