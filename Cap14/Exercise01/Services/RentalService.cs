using Exercise01.Entities;
using Exercise01.Services;
using System;

namespace Exercise01.Services
{
    class RentalService
    {
        public double PricePerHour { get; private set; }
        public double PricePerDay{ get; private set; }

        private BrazilTaxService brazilTaxService = new BrazilTaxService();

        public RentalService(double pricePerHour, double pricePerDay)
        {
            PricePerHour = pricePerHour;
            PricePerDay = pricePerDay;
        }

        public void ProcessInvoice(CarRental carRental)
        {
            TimeSpan rentalDuration = carRental.ReturnDate.Subtract(carRental.PickupDate);

            double basicPayment = 0;

            if (rentalDuration.TotalHours <= 12)
                basicPayment = Math.Ceiling(rentalDuration.TotalHours) * PricePerHour;
            else
                basicPayment = Math.Ceiling(rentalDuration.TotalDays) * PricePerDay;

            double tax = brazilTaxService.Tax(basicPayment);

            carRental.Invoice = new Invoice(basicPayment, tax);
        }
    }
}
