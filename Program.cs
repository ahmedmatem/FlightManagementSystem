using System.Globalization;
using System.Text;

namespace FlightManagementSystem
{
    #nullable disable

    public class Program
    {
        private const string filePath = "../../../flights.txt";

        private static List<Flight> flights = new List<Flight> ();
        private static string menuActionChoice;
        

        static void Main(string[] args)
        {
            // Console configuration
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            PrintMenu();

            LoadFlights();

            // MENU
            while (true)
            {
                menuActionChoice = Console.ReadLine();
                switch(menuActionChoice)
                {
                    case "1":
                        ShowActionTitle("Създаване на нов полет");
                        AddNewFlight();
                        break;
                    case "2":
                        BuyTicket();
                        break;
                    case "3":
                        ShowActionTitle("Търсене на полет по номер или дестинация");
                        SearchFlight();
                        break;
                    case "4":
                        ShowActionTitle("Списък на всички полети");
                        ListFlights();
                        break;
                    case "x" or "X":
                        Exit();
                        break;
                    default:
                        // todo: implement default case

                        break;
                }
            }
        }

        /// <summary>
        /// Saves all the fligths in the list of fligths into file.
        /// </summary>
        private static void SaveFlights()
        {
            StreamWriter writer = new StreamWriter(filePath, false, Encoding.Unicode);
            using (writer)
            {
                foreach (Flight flight in flights)
                {
                    writer.WriteLine(flight);
                }
            }
        }

        private static void LoadFlights()
        {
            StreamReader reader = new StreamReader(filePath, Encoding.Unicode);
            using (reader)
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] flightInfo = line.Split(',');
                    string flightId = flightInfo[0];
                    string destination = flightInfo[1];
                    DateTime departureTime = DateTime.ParseExact(flightInfo[2], Flight.DateTimeFormat,CultureInfo.InvariantCulture);
                    DateTime arrivalTime = DateTime.ParseExact(flightInfo[3], Flight.DateTimeFormat, CultureInfo.InvariantCulture);
                    int seatsAvailable = int.Parse(flightInfo[4]);
                    decimal price = decimal.Parse(flightInfo[5]);   

                    Flight currentFlight = new Flight(flightId,destination,departureTime,arrivalTime,seatsAvailable, price);
                    flights.Add(currentFlight);
                }
            }
        }

        private static void Exit()
        {
            Environment.Exit(0);
        }

        private static void ListFlights()
        {
            foreach(Flight flight in flights)
            {
                PrintFlightInfo(flight);
                AddLine();
            }

            BackToMenu();
        }

        private static void PrintFlightInfo(Flight flight)
        {
            Console.WriteLine($"\tНомер на полета: {flight.FlightID}");
            Console.WriteLine($"\tДо: {flight.Destination}");
            Console.WriteLine($"\tИзлитане: {flight.DepartureTime.ToString(Flight.DateTimeFormat)}");
            Console.WriteLine($"\tКацане: {flight.ArrivalTime.ToString(Flight.DateTimeFormat)}");
            Console.WriteLine($"\tСвободни места: {flight.SeatsAvailable}");
            Console.WriteLine($"\tЦена: {flight.Price}");
            AddLine();
        }

        private static void SearchFlight()
        {
            Console.Write("\tВъведете номер или дестинация на полет: ");
            string filter = Console.ReadLine();
            AddLine();

            var searchedFlights = flights
                .Where(f => f.FlightID == filter || f.Destination == filter)
                .ToList();
            if (searchedFlights.Count > 0)
            {
                foreach (var flight in searchedFlights)
                {
                    if (searchedFlights != null)
                    {
                        PrintFlightInfo(flight);
                    }
                }
            }
            else
            {
                ShowResultMessage($"Търсеният полет не е намерен.");
            }

            BackToMenu();
        }

        private static void BuyTicket()
        {
            throw new NotImplementedException();
        }

        private static void AddNewFlight()
        {
            Console.Write("\tНомер на полет: ");
            string flightId = Console.ReadLine();

            Console.Write("\tДестинация: ");
            string destination = Console.ReadLine();

            DateTime departureTime = DateTime.Now;
            DateTime arrivalTime = departureTime;
            try
            {
                Console.Write("\tДата и час на заминаване{дд-мм-гг чч:мм}: ");
                departureTime = DateTime.Parse(Console.ReadLine());

                Console.Write("\tДата и час на пристигане{дд-мм-гг чч:мм}: ");
                arrivalTime = DateTime.Parse(Console.ReadLine());
            }
            catch(Exception)
            {
                ShowResultMessage("Невалидна дата");
                BackToMenu();
                return;
            }            

            Console.Write("\tБрой места: ");
            int seatsAvailable = int.Parse(Console.ReadLine());

            Console.Write("\tЦена на полета: ");
            decimal price = decimal.Parse(Console.ReadLine());            

            try
            {
                Flight newFlight = new Flight(
                flightId,
                destination,
                departureTime,
                arrivalTime,
                seatsAvailable,
                price);

                flights.Add(newFlight);
                SaveFlights();

                ShowResultMessage($"Полет с номер {flightId} за {destination} е добавен успешно.");
            }
            catch (ArgumentException е)
            {
                ShowResultMessage(е.Message);
            }            

            BackToMenu();
        }

        private static void BackToMenu()
        {
            AddLine();
            Console.Write("\tНатисни произвлен клавиш обратно към МЕНЮ: ");
            Console.ReadLine();
            PrintMenu();
        }

        private static void PrintMenu()
        {
            Console.Clear();

            AddLine();
            Console.WriteLine("\tМ Е Н Ю");
            AddLine();
            Console.WriteLine("\tМоля изберете желаното действие:");
            AddLine();
            Console.WriteLine("\t[1]: Нов полет");
            Console.WriteLine("\t[2]: Купи билет");
            Console.WriteLine("\t[3]: Търсене на полет");
            Console.WriteLine("\t[4]: Справка на всички полети");
            Console.WriteLine("\t[x]: Изход от програмата");
            AddLine();
            Console.Write("\tВашият избор: ");
        }

        private static void AddLine(int count = 1)
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(Environment.NewLine);
            }
        }

        private static void ShowActionTitle(string title)
        {
            Console.Clear();
            AddLine();
            Console.WriteLine("\t" + title);
            AddLine();
        }

        private static void ShowResultMessage(string message)
        {
            AddLine();
            Console.WriteLine("\t" + message);
        }
    }
}
