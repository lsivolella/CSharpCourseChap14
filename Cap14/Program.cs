using Exercise01.Entities;
using Exercise01.Services;
using Exercise02.Entities;
using Exercise02.Services;
using Exercise03.Entities;
using Exercise03.Services;
using System;
using System.Globalization;

namespace Cap14
{
    class Program
    {
        static void Main(string[] args)
        {
            Exercise03();
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
    }
}
