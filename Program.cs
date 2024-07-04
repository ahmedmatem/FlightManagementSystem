namespace FlightManagementSystem
{
    #nullable disable

    public class Program
    {
        private static string menuActionChoice;
        private const string filePath = "../../../flights.txt";

        static void Main(string[] args)
        {
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
            throw new NotImplementedException();
        }
    }
}
