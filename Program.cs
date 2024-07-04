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

            while(true)
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
                        SearchFlight();
                        break;
                    case "4":
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

        private static void ShowActionTitle(string title)
        {
            Console.Clear();
            AddLine();
            Console.WriteLine("\t" + title);
            AddLine();
        }

        private static void LoadFlights()
        {
            StreamReader reader = new StreamReader(filePath, Encoding.Unicode);
            using (reader)
            {
                string line;
                while ((line = Console.ReadLine()) != null)
                {
                    string[] flightInfo = line.Split(',').ToArray();
                    string flightId = flightInfo[0];
                    string destination = flightInfo[1];
                    DateTime departureTime = Convert.ToDateTime(flightInfo[2]);
                    DateTime arrivalTime = Convert.ToDateTime(flightInfo[3]);
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
            throw new NotImplementedException();
        }

        private static void SearchFlight()
        {
            throw new NotImplementedException();
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

            Console.Write("\tДата и час на заминаване{дд-мм-гг чч:мм}: ");
            DateTime departureTime = DateTime.Parse(Console.ReadLine());

            Console.Write("\tДата и час на пристигане{дд-мм-гг чч:мм}: ");
            DateTime arrivalTime = DateTime.Parse(Console.ReadLine());

            Console.Write("\tБрой места: ");
            int seatsAvailable = int.Parse(Console.ReadLine());

            Console.Write("\tЦена на полета: ");
            decimal price = decimal.Parse(Console.ReadLine());

            Flight newFlight = new Flight(
                flightId,
                destination,
                departureTime,
                arrivalTime,
                seatsAvailable, 
                price);

            flights.Add(newFlight);
            SaveFlights();

            Console.WriteLine($"Полет с номер {flightId} за {destination} е добавен успешно.");

            BackToMenu();
        }

        private static void BackToMenu()
        {
            Console.Write("Натисни произвлен клавиш обратно към МЕНЮ: ");
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
            Console.WriteLine("\t[4]: Справка на свички полети");
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
    }
}
