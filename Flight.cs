using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementSystem
{
    public class Flight
    {
        private int seatsAvailable;
        private decimal price;
        private DateTime arrivalTime;

        public string FlightID { get; private set; }
        public string Destination { get; private set; }
        public DateTime DepartureTime { get; private set; }
        public DateTime ArrivalTime 
        {
            get
            {
                return arrivalTime;
            }
            private set
            {
                TimeSpan difference = value - DepartureTime;
                if (difference.Minutes <= 0)
                {
                    throw new ArgumentException("Часа на пристигане трябва да е по напред от часа на тръгване");
                }
                arrivalTime = value;
            }
        }
        public int SeatsAvailable {
            get
            {
                return seatsAvailable;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Наличните места трябва да са положителни!");
                }
                seatsAvailable = value;
            } 
        }
        public decimal Price { 
            get
            {
                return price;
            }
            private set 
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Цената на билета трябва да е  положително число!");
                }
            }
        }

        public Flight(string flightID, string destination, DateTime departureTime, DateTime arrivalTime, int seatsAvailable, decimal price)
        {
            FlightID = flightID;
            Destination = destination;
            DepartureTime = departureTime;
            ArrivalTime = arrivalTime;
            SeatsAvailable = seatsAvailable;
            Price = price;
        }
        public override string ToString()
        {
            return $"{FlightID},{Destination},{DepartureTime.ToString("dd-MM-yy hh:mm")},{ArrivalTime.ToString("dd-MM-yy hh:mm")},{SeatsAvailable},{Price}";
        }
        public void DecreaseSeats(int ticketsCount)
        {
            if (SeatsAvailable<ticketsCount)
            {
                Console.WriteLine("Няма толкова налични билети.");
                return;
            }
            SeatsAvailable -= ticketsCount;
            //todo: messige to be preint
        }
    }
}
