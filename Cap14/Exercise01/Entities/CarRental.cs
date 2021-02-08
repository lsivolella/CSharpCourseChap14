using System;

namespace Exercise01.Entities
{
    class CarRental
    {
        public DateTime PickupDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public Vehicle Vehicle { get; set; }
        public Invoice Invoice { get; set; }

        public CarRental(DateTime pickupDate, DateTime returnDate, Vehicle vehicle)
        {
            PickupDate = pickupDate;
            ReturnDate = returnDate;
            Vehicle = vehicle;
            Invoice = null;
        }
    }
}
