using Exercise02.Entities;
using Exercise02.Services;
using System;

namespace Exercise02.Services
{
    class RentalService2
    {
        public double PricePerHour { get; private set; }
        public double PricePerDay{ get; private set; }

        private ITaxService taxService;

        public RentalService2(double pricePerHour, double pricePerDay, ITaxService taxService)
        {
            PricePerHour = pricePerHour;
            PricePerDay = pricePerDay;
            this.taxService = taxService;
        }

        public void ProcessInvoice(CarRental2 carRental)
        {
            TimeSpan rentalDuration = carRental.ReturnDate.Subtract(carRental.PickupDate);

            double basicPayment = 0;

            if (rentalDuration.TotalHours <= 12)
                basicPayment = Math.Ceiling(rentalDuration.TotalHours) * PricePerHour;
            else
                basicPayment = Math.Ceiling(rentalDuration.TotalDays) * PricePerDay;

            double tax = taxService.Tax(basicPayment);

            carRental.Invoice = new Invoice2(basicPayment, tax);
        }
    }
}
