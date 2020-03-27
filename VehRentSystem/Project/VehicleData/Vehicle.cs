namespace Project.VehicleData
{
    class Vehicle
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int? YearMade { get; set; }
        public double? RentPrice { get; set; }
        public string tempRentPrice { get; set; }
        public bool RentStatus { get; set; } 
        public string RentFromDate { get; set; }
        public long? ClientNumber { get; set; }
        public Vehicle()
        {

        }
    }
}
