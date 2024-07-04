using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementSystem
{
    public class Flight
    {
        /*
         •	flightID: уникален идентификатор на полета (низ или цяло число)
•	destination: дестинация на полета (низ)
•	departureTime: време на излитане (дата и/или време, може и низ)
•	arrivalTime: време на пристигане (дата и/или време, може и низ)
•	seatsAvailable: налични места (цяло число)
•	price: цена на билет за полета (дробно число)

         */
        public string FlightID { get; private set; }
        public string Destination { get; private set; }
        public DateTime DepartureTime { get; private set; }
        public DateTime ArrivalTime { get; private set; }
        public int SeatsAvailable { get; private set; }
        public decimal Price { get; private set; }

        public Flight(string flightID, string destination, DateTime departureTime, DateTime arrivalTime, int seatsAvailable, decimal price)
        {
            FlightID = flightID;
            Destination = destination;
            DepartureTime = departureTime;
            ArrivalTime = arrivalTime;
            this.SeatsAvailable = seatsAvailable;
            Price = price;
        }
    }
}
