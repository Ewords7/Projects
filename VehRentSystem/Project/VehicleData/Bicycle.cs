namespace Project.VehicleData
{
    class Bicycle : Vehicle
    {
        public int? BikeID { get; set; }
        
        public Bicycle(int? bikeID = null, long? clientNumber = null, string brand = null, string model = null,
            string color = null, double? rentPrice = null, bool rentStatus = false, string rentFromDate = null) : base()
        {
            BikeID = bikeID;
            ClientNumber = clientNumber;
            Brand = brand;
            Model = model;
            Color = color;
            RentPrice = rentPrice;
            RentStatus = rentStatus;
            RentFromDate = rentFromDate;
        }   
    }
}
