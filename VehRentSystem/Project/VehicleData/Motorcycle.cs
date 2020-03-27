namespace Project.VehicleData
{
    class Motorcycle : Car
    {
        public Motorcycle(string motoNumber = null, string brand = null, string model = null, string engine = null,
            string color = null, int? year = null, double? rentPrice = null, bool rentStatus = false, string techServiceExp = null,
            string insuranceExp = null, string rentFromDate = null) : base()
        {
            VehNumber = motoNumber;
            Brand = brand;
            Model = model;
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
