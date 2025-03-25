using System.Globalization;

namespace Outcome_2_Assesment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] roomType = { "single", "double", "family" };
            bool isValidRoom = false;
            bool isValidNight = false;
            double total = 0;
            double cost = 0;
            double night = 0;
            const double discount = 10;
            string familyName = "";
            bool isValidDate = false;
            double totalVAT;
            DateTime userDate = DateTime.MinValue;


            Console.WriteLine("Enter your family name.");
            Console.Write(": ");
            familyName = Console.ReadLine();

            while (!isValidDate)
            {
                Console.WriteLine("Please enter a date (dd/MM/yyyy):");
                string userInput = Console.ReadLine();

                // These are the links that helped me with the DateTime
                //https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/exceptions/exception-handling
                //https://learn.microsoft.com/en-us/dotnet/api/system.datetime.tryparse?view=net-9.0

                try
                {
                    userDate = DateTime.ParseExact(userInput, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    Console.WriteLine("You entered: " + userDate.ToString("dd/MM/yyyy"));
                    isValidDate = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid date format. Please enter in dd/MM/yyyy format.");
                }
            }


            while (!isValidRoom)
            {
                Console.WriteLine("Enter what room type you would like(you can pick multiple by using commas).");
                Console.WriteLine("Max rooms per booking is 4.");
                Console.WriteLine("1. Single");
                Console.WriteLine("2. Double");
                Console.WriteLine("3. Family");
                Console.Write(": ");

                string input = Console.ReadLine().ToLower();

                roomType = input.Split(',');

                while (roomType.Length > 4)
                {
                    Console.WriteLine("You have gone over the maximum rooms");

                    Console.WriteLine("Enter what room type you would like(you can pick multiple by using commas).");
                    Console.WriteLine("Max rooms per booking is 4.");
                    Console.WriteLine("1. Single");
                    Console.WriteLine("2. Double");
                    Console.WriteLine("3. Family");
                    Console.Write(": ");

                    input = Console.ReadLine().ToLower();

                    roomType = input.Split(',');

                }


                foreach (string room in roomType)
                {
                    switch (room.Trim())
                    {
                        case "single":
                            isValidRoom = true;
                            cost = cost + 47;
                            break;
                        case "double":
                            isValidRoom = true;
                            cost = cost + 90;
                            break;
                        case "family":
                            isValidRoom = true;
                            cost = cost + 250;
                            break;
                        default:
                            Console.WriteLine("Enter a correct room type.");
                            break;
                    }
                }
            }


            // I used this line for one of my tests
            //Console.WriteLine($"£{cost:F2}");


            while (!isValidNight)
            {
                Console.WriteLine("How many nights would you like to stay?(Max amount of nights is 14)");
                Console.Write(": ");

                night = double.Parse(Console.ReadLine());

                if (night < 1)
                {
                    Console.WriteLine("Haha good try but you cant have less than 1 night stay");
                }
                else if (night > 14)
                {
                    Console.WriteLine("The maximum amount of nights is 14");
                }
                else
                {
                    Console.WriteLine($"You have chosen {night} nights");
                    isValidNight = true;
                }
            }

            if (roomType.Length >= 3)
            {
                if (night >= 7)
                {
                    Console.WriteLine("You have been awarded a 10% discount");
                    cost = cost * night;
                    total = cost / 100 * discount;
                    total = cost - total;
                    
                }
                else
                {
                    Console.WriteLine("You cant get the 10% discount as you are staying less than 7 nights.");
                    total = cost * night;
                   
                }
            }
            else
            {
                Console.WriteLine("You cant get the 10% discount as you have booked less than 3 rooms.");
                total = cost * night;
         
            }
            totalVAT = total * 1.20;

            // I used this line for one of my tests
            //Console.WriteLine(total);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"Date:{userDate} for {night} nights ");
            Console.WriteLine();
            Console.WriteLine("-----------------------------");
            Console.WriteLine("------ YOUR TOTAL BILL ------");
            Console.WriteLine("-------------FOR-------------");
            Console.WriteLine($"------------FAMILY-----------");
            Console.WriteLine($"-------------{familyName}------------");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(" -----------------------------");
            Console.WriteLine("|                             |");
            Console.WriteLine($"|   SubTotal: £{total:F2}        |");
            Console.WriteLine($"|                             |");
            Console.WriteLine($"|   VAT (20%): £{(totalVAT - total):F2}        |");
            Console.WriteLine($"|                             |");
            Console.WriteLine($"|   Total: £{totalVAT:F2}           |");
            Console.WriteLine($"|                             |");
            Console.WriteLine(" -----------------------------");

        }
    }
}