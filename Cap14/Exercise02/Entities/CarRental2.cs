using System;

namespace Exercise02.Entities
{
    class CarRental2
    {
        public DateTime PickupDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public Vehicle2 Vehicle { get; set; }
        public Invoice2 Invoice { get; set; }

        public CarRental2(DateTime pickupDate, DateTime returnDate, Vehicle2 vehicle)
        {
            PickupDate = pickupDate;
            ReturnDate = returnDate;
            Vehicle = vehicle;
            Invoice = null;
        }
    }
}
