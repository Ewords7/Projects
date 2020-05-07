using System;
namespace Project.Functions
{
    class VehicleMenagement
    {
        private bool rentStatus;
        private DateTime todayDate = DateTime.Today;
        public string tempRentPrice { get; set; }
        
        public VehicleMenagement()
        {
        }

        // Transporto priemones isnuomojimas
        public Tuple<DateTime, bool> VehRenting()
        {
            rentStatus = true;
            Console.Clear();
            Console.WriteLine("Transporto priemone sekmingai isnuomota");
            Console.ReadKey();

            return new Tuple<DateTime, bool>(todayDate, rentStatus);
        }        
    }
}
