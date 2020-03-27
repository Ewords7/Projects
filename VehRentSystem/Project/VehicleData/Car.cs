namespace Project.VehicleData
{
    class Car : Vehicle
    {
        public string VehNumber { get; set; }
        public string CarType { get; set; }
        public string FuelType { get; set; }
        public string Engine { get; set; }
        public string TechServiceExp { get; set; }
        public string InsuranceExp { get; set; }
        public Car(string carNumber = null, long? clientNumber = null, string brand = null, string model = null,
            string carType = null, string fuelType = null, string engine = null, string color = null, int? year = null,
            double? rentPrice = null, bool rentStatus = false, string techServiceExp = null, string insuranceExp = null,
            string rentFromDate = null) : base()
        {
            VehNumber = carNumber;
            ClientNumber = clientNumber;
            Brand = brand;
            Model = model;
            CarType = carType;
            FuelType = fuelType;
            Engine = engine;
            Color = color;
            YearMade = year;
            RentPrice = rentPrice;
            RentStatus = rentStatus;
            TechServiceExp = techServiceExp;
            InsuranceExp = insuranceExp;
            RentFromDate = rentFromDate;
        }        
    }
}
