using Project.SQLQueries;
using Project.VehicleData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Project.Functions
{
    class CarManagement
    {
        private int tempYearMade;
        private const int todaysYear = 2020;
        private bool trueValue = true;
        private double? totalPrice;
        private int y = 2;
        private string techServiceExp;
        private string insuranceExp;
        private DateTime todayDate = DateTime.Today;
        private SQLSelect SqlQueries = new SQLSelect();
        private Car car = new Car();
        private Regex letters = new Regex("^[a-zA-Z/]*$");
        private Regex doubleNumbers = new Regex("^[0-9.]*$");
        private Regex date = new Regex("^[0-9.-]*$");
        public string tempRentPrice { get; set; }
        public CarManagement()
        {

        }

        // Automobilio iraso kurimas su ivedimo patikrinimu
        public Car MakeCarRecord()
        {
            Console.WriteLine("\nIvesk automobilio marke");
            car.Brand = Console.ReadLine();
            while (car.Brand == "")
            {
                Console.WriteLine($"\nNeivesta automobilio marke!\nIvesk automobilio marke");
                car.Brand = Console.ReadLine();
            }

            Console.WriteLine("\nIvesk automobilio modeli");
            car.Model = Console.ReadLine();
            while (car.Model == "")
            {
                Console.WriteLine($"\nNeivestas automobilio modelis!\nIvesk automobilio modeli");
                car.Model = Console.ReadLine();
            }

            Console.WriteLine("\nIvesk automobilio kebulo tipa");
            car.CarType = Console.ReadLine();
            while (!letters.IsMatch(car.CarType) || car.CarType == "")
            {
                Console.WriteLine($"\nIvesti galima tik raides!\nIvesk automobilio kebulo tipa");
                car.CarType = Console.ReadLine();
            }

            Console.WriteLine("\nIvesk automobilio kuro tipa");
            car.FuelType = Console.ReadLine();
            while (!letters.IsMatch(car.FuelType) || car.FuelType == "")
            {
                Console.WriteLine($"\nIvesti galima tik raides!\nIvesk automobilio kuro tipa");
                car.FuelType = Console.ReadLine();
            }

            Console.WriteLine("\nIvesk automobilio variklio turi");
            car.Engine = Console.ReadLine();

            Console.WriteLine("\nIvesk automobilio spalva");
            car.Color = Console.ReadLine();
            while (!letters.IsMatch(car.Color))
            {
                Console.WriteLine($"\nIvesti galima tik raides!\nIvesk automobilio spalva");
                car.Color = Console.ReadLine();
            }

            Console.WriteLine("\nIvesk automobilio pagaminimo metus");
            do
            {
                while (!int.TryParse(Console.ReadLine(), out tempYearMade))
                {
                    Console.WriteLine("\nIvesti galima tik skaitmenis!\nIvesk automobilio pagaminimo metus");
                }
                // Patikrinama ar automobilio metai yra nustatytuose reziuose
                if (tempYearMade > todaysYear || tempYearMade < 1970)
                {
                    Console.WriteLine("\nIvesti netinkami pagaminimo metai! Metai turi buti ivedami tarp 1970 - 2020" +
                        "\nIvesk automobilio pagaminimo metus");
                }
                else
                {
                    trueValue = false;
                }
            } while (trueValue);
            car.YearMade = tempYearMade;

            Console.WriteLine("\nIvesk automobilio nuomos kaina parai");
            tempRentPrice = Console.ReadLine();
            while (!doubleNumbers.IsMatch(tempRentPrice) || tempRentPrice == "")
            {
                Console.WriteLine($"\nNuomos kainai ivesti naudok tik skaicius ir tasko(.) simboli!\nIvesk nuomos kaina is naujo");
                tempRentPrice = Console.ReadLine();
            }
            car.RentPrice = Convert.ToDouble(tempRentPrice);

            Console.WriteLine("\nIvesk data iki kada galioja automobilio TA");
            car.TechServiceExp = Console.ReadLine();
            while (!date.IsMatch(car.TechServiceExp) || car.TechServiceExp == "")
            {
                Console.WriteLine($"\nIvedimui naudok tik skaicius, tasko(.) ir bruksnio(-) simbolius!\nIvesk iki kada galioja TA");
                car.TechServiceExp = Console.ReadLine();
            }

            Console.WriteLine("\nIvesk data iki kada galioja automobilio draudimas");
            car.InsuranceExp = Console.ReadLine();
            while (!date.IsMatch(car.InsuranceExp) || car.InsuranceExp == "")
            {
                Console.WriteLine($"\nIvedimui naudok tik skaicius, tasko(.) ir bruksnio(-) simbolius!\nIvesk iki kada galioja draudimas");
                car.InsuranceExp = Console.ReadLine();
            }
            Console.Clear();
            Console.WriteLine("Transporto priemone sekmingai prideta i sistema");
            Console.ReadKey();

            return new Car(car.VehNumber, car.ClientNumber, car.Brand, car.Model, car.CarType, car.FuelType, car.Engine, car.Color,
                car.YearMade, car.RentPrice, car.RentStatus, car.TechServiceExp, car.InsuranceExp);
        }

        // Tam tikru automobilio duomenu redagavimas su ivedimo patikrinimu
        public Tuple<string, double?> EditCarData()
        {
            Console.WriteLine("Ivesk automobilio spalva");
            car.Color = Console.ReadLine();
            while (!letters.IsMatch(car.Color))
            {
                Console.WriteLine($"\nIvesti galima tik raides!\nIvesk automobilio spalva");
                car.Color = Console.ReadLine();
            }

            Console.WriteLine("Ivesk automobilio nuomos kaina");
            tempRentPrice = Console.ReadLine();
            while (!doubleNumbers.IsMatch(tempRentPrice) || tempRentPrice == "")
            {
                Console.WriteLine($"\nNuomos kainai ivesti naudok tik skaicius ir tasko(.) simboli! Ivesk nuomos kaina is naujo");
                tempRentPrice = Console.ReadLine();
            }
            car.RentPrice = Convert.ToDouble(tempRentPrice);

            Console.Clear();
            Console.WriteLine("Automobilio duomenys sekmingai pakoreguoti");
            Console.ReadKey();

            return new Tuple<string, double?>(car.Color, car.RentPrice);
        }

        // Automobilio dokumentu galiojimo laiko redagavimas su ivedamu duomenu patikrinimu
        public Tuple<string, string> EditCarDocsData(string vehNumber)
        {
            List<Car> cars = SqlQueries.SelectCars();

            var result = cars.Select(c => c).Where(c => c.VehNumber == vehNumber);
            
            Console.WriteLine("Ivesk iki kada galioja automobilio TA");
            car.TechServiceExp = Console.ReadLine();
            if (car.TechServiceExp == "")
            {
                foreach (var car in result)
                {
                    techServiceExp = car.TechServiceExp;
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    Console.WriteLine(techServiceExp);
                }
            }
            else
            {
                while (!date.IsMatch(car.TechServiceExp) || car.TechServiceExp == "")
                {
                    Console.WriteLine($"\nIvedimui naudok tik skaicius, tasko(.) ir bruksnio(-) simbolius! Ivesk iki kada galioja TA");
                    car.TechServiceExp = Console.ReadLine();                    
                }
                techServiceExp = car.TechServiceExp;
            }

            Console.WriteLine("Ivesk iki kada galioja automobilio draudimas");
            car.InsuranceExp = Console.ReadLine();
            if (car.InsuranceExp == "")
            {
                foreach (var car in result)
                {
                    insuranceExp = car.InsuranceExp;
                }
            }
            else
            {
                while (!date.IsMatch(car.InsuranceExp) || car.InsuranceExp == "")
                {
                    Console.WriteLine($"\nIvedimui naudok tik skaicius, tasko(.) ir bruksnio(-) simbolius! Ivesk iki kada galioja draudimas");
                    car.InsuranceExp = Console.ReadLine();
                }
                insuranceExp = car.InsuranceExp;
            }

            Console.Clear();
            Console.WriteLine("Duomenys sekmingai atnaujinti");
            Console.ReadKey();

            return new Tuple<string, string>(techServiceExp, insuranceExp);
        }

        // Automobilio grazinimas
        public bool CarGivedBack(string vehNumber)
        {
            List<Car> cars = SqlQueries.SelectCarsWithClient();

            var result = cars.Select(c => c).Where(c => c.VehNumber == vehNumber);

            foreach (var car in result)
            {
                // Skaciavimas kiek dienu buvo isnuomotas automobilis
                DateTime rentDay = Convert.ToDateTime(car.RentFromDate);
                double days = (todayDate - rentDay).TotalDays;

                if (days == 0)
                {
                    // Nuomos kaina, jei automobilis grazinamas ta pacia diena
                    totalPrice = car.RentPrice;
                }
                else
                {
                    // Kainos skaiciavimas uz visa nuomos laika
                    totalPrice = car.RentPrice * days;
                }
            }

            car.RentStatus = false;
            
            Console.Clear();
            Console.WriteLine($"Transporto priemone grazinta\nTransporto priemones kaina uz visa nuomos laikotarpi: {totalPrice} Eur");
            Console.ReadKey();

            return car.RentStatus;
        }

        // Automobilio duomenu isvedimas i ekrana
        public void PrintAllData()
        {
            List<Car> cars = SqlQueries.SelectCars();

            Console.Clear();
            Console.WriteLine("Numeris | Marke | Modelis | Kebulas | Kuras | Variklis | Spalva | Metai | Nuomos kaina | TA | Draudimas\n");

            var result = cars.Select(c => c).OrderBy(c => c.Brand).OrderBy(c => c.Model);            
            
            foreach (var car in result)
            {
                Console.WriteLine($"{car.VehNumber} | {car.Brand} | {car.Model} | {car.CarType} | {car.FuelType} | {car.Engine} | " +
                    $"{car.Color} | {car.YearMade} | {car.RentPrice} | {car.TechServiceExp} | {car.InsuranceExp}");
            }
            
            Console.ReadKey();
        }

        // Galimu isnuomoti automobiliu isvedimas i ekrana
        public void AvailableCarsToRentData()
        {
            List<Car> cars = SqlQueries.SelectCars();

            Console.Clear();
            Console.WriteLine("Numeris | Marke | Modelis | Kebulas | Kuras | Variklis | Spalva | Metai | Nuomos kaina | TA | Draudimas\n");
            
            var result = cars.Select(c => c).Where(c => c.RentStatus == false).OrderBy(c => c.Brand).ThenBy(c => c.Model);
            
            foreach (var car in result)
            {
                // TA ir draudimo kovertavimas i DateTime
                DateTime dateTS = Convert.ToDateTime(car.TechServiceExp);
                DateTime dateInsurance = Convert.ToDateTime(car.InsuranceExp);
                // TA ir draudimo datu palyginimas su siandienine data
                int isTSValid = DateTime.Compare(dateTS, todayDate);
                int isInsuranceValid = DateTime.Compare(dateInsurance, todayDate);

                // Patikrinimas ar galio TA ir draudimas
                if (isTSValid >= 0 && isInsuranceValid >= 0)
                {
                    Console.WriteLine($"{car.VehNumber} | {car.Brand} | {car.Model} | {car.CarType} | {car.FuelType} | {car.Engine} | " +
                        $"{car.Color} | {car.YearMade} | {car.RentPrice} | {car.TechServiceExp} | {car.InsuranceExp}");
                }
            }
            Console.ReadKey();
        }

        // Isnuomotu automobiliu isvedimas i ekrana
        public virtual void RentedCarsData()
        {
            List<Car> cars = SqlQueries.SelectCars();

            Console.Clear();
            Console.WriteLine("Numeris | Marke | Modelis | Kebulas | Kuras | Variklis | Spalva | Metai | Nuomos kaina | TA | Draudimas\n");
            
            var result = cars.Select(c => c).Where(c => c.RentStatus == true).OrderBy(c => c.Brand).ThenBy(c => c.Model);
            
            foreach (var car in result)
            {
                Console.WriteLine($"{car.VehNumber} | {car.Brand} | {car.Model} | {car.CarType} | {car.FuelType} | {car.Engine} | " +
                    $"{car.Color} | {car.YearMade} | {car.RentPrice} | {car.TechServiceExp} | {car.InsuranceExp}");
            }
            
            Console.ReadKey();
        }

        // Automobiliu turinciu nebegaliojacius ar besibaigiancius galioti TA ar draudimo dokumentus isvedimas i ekrana
        public virtual void ValidDocsData()
        {
            List<Car> cars = SqlQueries.SelectCars();

            Console.CursorVisible = false;
            Console.Clear();
            Console.WriteLine("Numeris");
            Console.SetCursorPosition(10, 0);
            Console.WriteLine("Marke");
            Console.SetCursorPosition(30, 0);
            Console.WriteLine("Modelis");
            Console.SetCursorPosition(50, 0);
            Console.WriteLine("TA");
            Console.SetCursorPosition(70, 0);
            Console.WriteLine("Draudimas\n");

            var result = cars.Select(c => c).OrderBy(c => c.Brand).ThenBy(c => c.Model);

            foreach (var car in result)
            {
                // Datos konvertavimas i DateTime
                DateTime dateTS = Convert.ToDateTime(car.TechServiceExp);
                DateTime dateInsurance = Convert.ToDateTime(car.InsuranceExp);
                // Skaiciavimas kiek dienu liko iki TA ir draudimo galiojimo laiko pabaigos
                double isTSValid = (dateTS - todayDate).TotalDays;
                double isInsuranceValid = (dateInsurance - todayDate).TotalDays;
                // Patikrinimas ar TA ir draudimas dar galioja
                if (isTSValid < 0 && isInsuranceValid < 0)
                {
                    Console.SetCursorPosition(0, y);
                    Console.WriteLine(car.VehNumber);
                    Console.SetCursorPosition(10, y);
                    Console.WriteLine(car.Brand);
                    Console.SetCursorPosition(30, y);
                    Console.WriteLine(car.Model);
                    Console.SetCursorPosition(50, y);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(car.TechServiceExp);
                    Console.SetCursorPosition(70, y);
                    Console.WriteLine(car.InsuranceExp);
                    Console.ResetColor();
                    Console.SetCursorPosition(90, y);
                    y++;
                }
                else if (isTSValid < 0)
                {
                    Console.SetCursorPosition(0, y);
                    Console.WriteLine(car.VehNumber);
                    Console.SetCursorPosition(10, y);
                    Console.WriteLine(car.Brand);
                    Console.SetCursorPosition(30, y);
                    Console.WriteLine(car.Model);
                    Console.SetCursorPosition(50, y);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(car.TechServiceExp);
                    Console.ResetColor();
                    Console.SetCursorPosition(70, y);
                    Console.WriteLine(car.InsuranceExp);
                    Console.SetCursorPosition(90, y);
                    y++;
                }
                else if (isInsuranceValid < 0)
                {
                    Console.SetCursorPosition(0, y);
                    Console.WriteLine(car.VehNumber);
                    Console.SetCursorPosition(10, y);
                    Console.WriteLine(car.Brand);
                    Console.SetCursorPosition(30, y);
                    Console.WriteLine(car.Model);
                    Console.SetCursorPosition(50, y);
                    Console.WriteLine(car.TechServiceExp);
                    Console.SetCursorPosition(70, y);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(car.InsuranceExp);
                    Console.ResetColor();
                    Console.SetCursorPosition(90, y);
                    y++;
                }
                // Patikrinimas ar TA ir draudimas galioja daugiau nei 31 diena
                else if (isTSValid >= 0 && isTSValid < 32 && isInsuranceValid >= 0 && isInsuranceValid < 32)
                {                    
                    Console.SetCursorPosition(0, y);
                    Console.WriteLine(car.VehNumber);
                    Console.SetCursorPosition(10, y);
                    Console.WriteLine(car.Brand);
                    Console.SetCursorPosition(30, y);
                    Console.WriteLine(car.Model);
                    Console.SetCursorPosition(50, y);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(car.TechServiceExp);
                    Console.SetCursorPosition(70, y);
                    Console.WriteLine(car.InsuranceExp);
                    Console.SetCursorPosition(90, y);
                    Console.ResetColor();
                    y++;
                }
                else if (isTSValid >= 0 && isTSValid < 32)
                {
                    Console.SetCursorPosition(0, y);
                    Console.WriteLine(car.VehNumber);
                    Console.SetCursorPosition(10, y);
                    Console.WriteLine(car.Brand);
                    Console.SetCursorPosition(30, y);
                    Console.WriteLine(car.Model);
                    Console.SetCursorPosition(50, y);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(car.TechServiceExp);
                    Console.ResetColor();
                    Console.SetCursorPosition(70, y);
                    Console.WriteLine(car.InsuranceExp);
                    Console.SetCursorPosition(90, y);
                    y++;
                }
                else if (isInsuranceValid >= 0 && isInsuranceValid < 32)
                {
                    Console.SetCursorPosition(0, y);
                    Console.WriteLine(car.VehNumber);
                    Console.SetCursorPosition(10, y);
                    Console.WriteLine(car.Brand);
                    Console.SetCursorPosition(30, y);
                    Console.WriteLine(car.Model);
                    Console.SetCursorPosition(50, y);
                    Console.WriteLine(car.TechServiceExp);
                    Console.SetCursorPosition(70, y);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(car.InsuranceExp);
                    Console.ResetColor();
                    Console.SetCursorPosition(90, y);
                    y++;
                }
            }

            Console.ReadKey();
            y = 2;
        }

        // Isnuomotos transporto priemones ir nuomininko paieska pagal automobilio numeri
        public void SearchByCar(bool carNumExist, string vehNumber)
        {
            if (carNumExist)
            {
                List<Car> cars = SqlQueries.SelectCarsWithClient();
                List<Client> clients = SqlQueries.SelectClients();

                Console.Clear();

                var result = (from c in cars
                              join cl in clients on c.ClientNumber equals cl.PersonalNumber
                              select new
                              {
                                  c.VehNumber,
                                  c.Brand,
                                  c.Model,
                                  cl.PersonalNumber,
                                  cl.Name,
                                  cl.Surename
                              }).Where(c => c.VehNumber == vehNumber).OrderBy(c => c.Brand);

                foreach (var car in result)
                {
                    Console.WriteLine($"Automobilis: {car.Brand} {car.Model}\nNuomininkas: {car.Name} {car.Surename} " +
                        $"(a.k. {car.PersonalNumber})");
                }

                Console.ReadKey();
            }
        }
    }
}
