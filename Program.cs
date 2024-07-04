using System.Text;

namespace FlightManagementSystem
{
    #nullable disable

    public class Program
    {
        private static string menuActionChoice;
        private const string filePath = "../../../flights.txt";

        static void Main(string[] args)
        {
            // Console configuration
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            PrintMenu();

            while(true)
            {
                menuActionChoice = Console.ReadLine();
                switch(menuActionChoice)
                {
                    case "1":
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

        private static void Exit()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        private static void PrintMenu()
        {
            Console.Clear();

            Console.WriteLine("\tМ Е Н Ю");
            AddLine(2);
            Console.WriteLine("\tМоля изберете желаното действие:");
            AddLine(2);
            Console.WriteLine("\t[1]: Нов полет");
            Console.WriteLine("\t[2]: Купи билет");
            Console.WriteLine("\t[3]: Търсене на полет");
            Console.WriteLine("\t[4]: Справка на свички полети");
            Console.WriteLine("\t[x]: Изход от програмата");
            AddLine(2);
            Console.Write("\tВашият избор: ");
        }

        private static void AddLine(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(Environment.NewLine);
            }
        }
    }
}
