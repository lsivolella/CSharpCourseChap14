using Exercise04.Entities;
using Exercise01.Entities;
using Exercise01.Services;
using Exercise02.Entities;
using Exercise02.Services;
using Exercise03.Entities;
using Exercise03.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Exercise05.Entities;
using Exercise05.Enums;

namespace Cap14
{
    class Program
    {
        static void Main(string[] args)
        {
            Exercise05();
        }

        private static void Exercise01()
        {
            Console.WriteLine("Enter rental data:");
            Console.Write("Car Model: ");
            string model = Console.ReadLine();
            Console.Write("Pickup Date (dd/mm/yyy hh:mm): ");
            DateTime pickupDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
            Console.Write("Return Date (dd/mm/yyy hh:mm): ");
            DateTime returnDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
            Console.Write("Enter Price per Hour: ");
            double pricePerDay = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Enter Price per Day: ");
            double pricePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            CarRental carReltal = new CarRental(pickupDate, returnDate, new Vehicle(model));

            RentalService rentalService = new RentalService(pricePerDay, pricePerHour);

            rentalService.ProcessInvoice(carReltal);

            Console.WriteLine();
            Console.WriteLine("Invoice:");
            Console.WriteLine(carReltal.Invoice.ToString());
        }

        private static void Exercise02()
        {
            Console.WriteLine("Enter rental data:");
            Console.Write("Car Model: ");
            string model = Console.ReadLine();
            Console.Write("Pickup Date (dd/mm/yyy hh:mm): ");
            DateTime pickupDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
            Console.Write("Return Date (dd/mm/yyy hh:mm): ");
            DateTime returnDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
            Console.Write("Enter Price per Hour: ");
            double pricePerDay = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Enter Price per Day: ");
            double pricePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            CarRental2 carReltal = new CarRental2(pickupDate, returnDate, new Vehicle2(model));

            RentalService2 rentalService = new RentalService2(pricePerDay, pricePerHour, new BrazilTaxService2());

            rentalService.ProcessInvoice(carReltal);

            Console.WriteLine();
            Console.WriteLine("Invoice:");
            Console.WriteLine(carReltal.Invoice.ToString());
        }

        private static void Exercise03()
        {
            Console.WriteLine("Enter Contract Data: ");
            Console.Write("Contract Number: ");
            int number = int.Parse(Console.ReadLine());
            Console.Write("Contract Date: ");
            DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            Console.Write("Contract Value: ");
            double totalValue = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Number of Installments: ");
            int monthsDuration = int.Parse(Console.ReadLine());

            Contract contract = new Contract(number, date, totalValue);

            ContractService contractService = new ContractService(new PaypalService());

            contractService.ProcessContract(contract, monthsDuration);

            Console.WriteLine();
            Console.WriteLine("Installments:");
            foreach (Installment installment in contract.Installments)
            {
                Console.WriteLine(installment.ToString());
            }
        }

        private static void Exercise04()
        {
            string filePath = @"C:\Users\lucas\source\repos\C#Projects\Curso C# Completo\Cap14\Data\names.txt";

            try
            {
                using (StreamReader streamReader = File.OpenText(filePath))
                {
                    List<Employee> nameList = new List<Employee>();

                    while (!streamReader.EndOfStream)
                    {
                        nameList.Add(new Employee(streamReader.ReadLine()));
                    }

                    nameList.Sort();

                    foreach (Employee employee in nameList)
                    {
                        Console.WriteLine(employee);
                    }
                }
            }
            catch (IOException error)
            {
                Console.WriteLine("An error ocurred:");
                Console.WriteLine(error.Message);
            }
        }

        private static void Exercise05()
        {
            try
            {
                Card sixHearts = new Card("six", Suit.Hearts, 5);
                Card aceSpaces = new Card("ace", Suit.Spades, 13);
                Card eightHearts = new Card("eight", Suit.Hearts, 7);
                Card threeDiamonds = new Card("three", Suit.Diamonds, 2);
                Card twoDiamonds = new Card("two", Suit.Diamonds, 1);

                List<Card> playerHand = new List<Card>();

                playerHand.Add(sixHearts);
                playerHand.Add(aceSpaces);
                playerHand.Add(eightHearts);
                playerHand.Add(threeDiamonds);
                playerHand.Add(twoDiamonds);

                Console.WriteLine("Unsorted Hand: ");
                foreach (Card card in playerHand)
                {
                    Console.WriteLine(card.ToString());
                }

                Console.WriteLine();
                Console.WriteLine("Sorted Hand: ");

                // playerHand.Sort((IComparer<Card>)new Compare());
                playerHand.Sort();

                foreach (Card card in playerHand)
                {
                    Console.WriteLine(card.ToString());
                }
            }
            catch (IOException error)
            {
                Console.WriteLine("An error ocurred: ");
                Console.WriteLine(error.Message);
            }


        }
    }
}
