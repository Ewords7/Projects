using Project.Repository;
using Project.VehicleData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Project.Functions
{
    class MotoManagement
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
        private Motorcycle moto = new Motorcycle();
        private Regex letters = new Regex("^[a-zA-Z/]*$");
        private Regex doubleNumbers = new Regex("^[0-9.]*$");
        private Regex date = new Regex("^[0-9.-]*$");
        public string tempRentPrice { get; set; }
        public MotoManagement()
        {

        }

        // Motociklo iraso ivedimas su ivedimo patikrinimu
        public Motorcycle MakeMotoRecord()
        {
            Console.WriteLine("\nIvesk motociklo marke");
            moto.Brand = Console.ReadLine();
            while (moto.Brand == "")
            {
                Console.WriteLine($"\nNeivesta motociklo marke!\nIvesk motociklo marke");
                moto.Brand = Console.ReadLine();
            }

            Console.WriteLine("\nIvesk motociklo modeli");
            moto.Model = Console.ReadLine();
            while (moto.Model == "")
            {
                Console.WriteLine($"\nNeivestas motociklo modelis!\nIvesk motociklo modeli");
                moto.Model = Console.ReadLine();
            }

            Console.WriteLine("\nIvesk motociklo variklio turi");
            moto.Engine = Console.ReadLine();
            while (moto.Engine == "")
            {
                Console.WriteLine($"\nNeivestas motociklo variklio turis!\nIvesk motociklo variklio turi");
                moto.Engine = Console.ReadLine();
            }

            Console.WriteLine("\nIvesk motociklo spalva");
            moto.Color = Console.ReadLine();
            while (!letters.IsMatch(moto.Color))
            {
                Console.WriteLine($"\nIvesti galima tik raides ir (/) simboli!\nIvesk motociklo spalva");
                moto.Color = Console.ReadLine();
            }

            Console.WriteLine("\nIvesk motociklo pagaminimo metus");
            do
            {
                while (!int.TryParse(Console.ReadLine(), out tempYearMade))
                {
                    Console.WriteLine("\nIvesti galima tik skaitmenis!\nIvesk automobilio pagaminimo metus");
                }
                if (tempYearMade > todaysYear || tempYearMade < 1970)
                {
                    Console.WriteLine("\nBlogai ivesti pagaminimo metai!\nIvesk automobilio pagaminimo metus");
                }
                else
                {
                    trueValue = false;
                }
            } while (trueValue);
            moto.YearMade = tempYearMade;

            Console.WriteLine("\nIvesk motociklo nuomos kaina parai");
            tempRentPrice = Console.ReadLine();
            while (!doubleNumbers.IsMatch(tempRentPrice) || tempRentPrice == "")
            {
                Console.WriteLine($"\nNuomos kainai ivesti naudok tik skaicius ir tasko(.) simboli!\nIvesk nuomos kaina is naujo");
                tempRentPrice = Console.ReadLine();
            }
            moto.RentPrice = Convert.ToDouble(tempRentPrice);

            Console.WriteLine("\nIvesk data iki kada galioja motociklo TA");
            moto.TechServiceExp = Console.ReadLine();
            while (!date.IsMatch(moto.TechServiceExp) || moto.TechServiceExp == "")
            {
                Console.WriteLine($"\nIvedimui naudok tik skaicius, tasko(.) ir bruksnio(-) simbolius!\nIvesk iki kada galioja TA");
                moto.TechServiceExp = Console.ReadLine();
            }

            Console.WriteLine("\nIvesk data iki kada galioja motociklo draudimas");
            moto.InsuranceExp = Console.ReadLine();
            while (!date.IsMatch(moto.InsuranceExp) || moto.InsuranceExp == "")
            {
                Console.WriteLine($"\nIvedimui naudok tik skaicius, tasko(.) ir bruksnio(-) simbolius!\nIvesk iki kada galioja draudimas");
                moto.InsuranceExp = Console.ReadLine();
            }

            Console.Clear();
            Console.WriteLine("Transporto priemone sekmingai prideta i sistema");
            Console.ReadKey();

            return new Motorcycle(moto.VehNumber, moto.Brand, moto.Model, moto.Engine, moto.Color, moto.YearMade, moto.RentPrice,
                moto.RentStatus, moto.TechServiceExp, moto.InsuranceExp);
        }

        // Motociklo tam tikru duomenu redagavimas su ivedimo patikrinimu
        public Tuple<string, double?> EditData()
        {
                Console.WriteLine("Ivesk motociklo spalva");
                moto.Color = Console.ReadLine();
                while (!letters.IsMatch(moto.Color))
                {
                    Console.WriteLine($"\nSpalvos ivedimui naudok tik raides ir (/) simboli!\nIvesk motociklo spalva");
                    moto.Color = Console.ReadLine();
                }
                Console.WriteLine("Ivesk motociklo nuomos kaina");
                tempRentPrice = Console.ReadLine();
                while (!doubleNumbers.IsMatch(tempRentPrice) || tempRentPrice == "")
                {
                    Console.WriteLine($"\nNuomos kainai ivesti naudok tik skaicius ir tasko(.) simboli!\nIvesk nuomos kaina is naujo");
                    tempRentPrice = Console.ReadLine();
                }
                moto.RentPrice = Convert.ToDouble(tempRentPrice);

                Console.Clear();
                Console.WriteLine("Duomenys sekmingai pakoreguoti");
                Console.ReadKey();

            return new Tuple<string, double?>(moto.Color, moto.RentPrice);
        }

        // Motociklo TA ir draudimo galiojimo datos redagavimas su ivedimo tikrinimu
        public Tuple<string, string> EditMotoDocsData(string vehNumber)
        {
            List<Motorcycle> motos = SqlQueries.SelectMotorcycles();

            var result = motos.Select(m => m).Where(m => m.VehNumber == vehNumber);

            Console.WriteLine("Ivesk iki kada galioja automobilio TA");
            moto.TechServiceExp = Console.ReadLine();
            if (moto.TechServiceExp == "")
            {
                foreach (var moto in result)
                {
                    techServiceExp = moto.TechServiceExp;
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    Console.WriteLine(techServiceExp);
                }
            }
            else
            {
                while (!date.IsMatch(moto.TechServiceExp) || moto.TechServiceExp == "")
                {
                    Console.WriteLine($"\nIvedimui naudok tik skaicius, tasko(.) ir bruksnio(-) simbolius! Ivesk iki kada galioja TA");
                    moto.TechServiceExp = Console.ReadLine();
                }
                techServiceExp = moto.TechServiceExp;
            }

            Console.WriteLine("Ivesk iki kada galioja automobilio draudimas");
            moto.InsuranceExp = Console.ReadLine();
            if (moto.InsuranceExp == "")
            {
                foreach (var car in result)
                {
                    insuranceExp = car.InsuranceExp;
                }
            }
            else
            {
                while (!date.IsMatch(moto.InsuranceExp) || moto.InsuranceExp == "")
                {
                    Console.WriteLine($"\nIvedimui naudok tik skaicius, tasko(.) ir bruksnio(-) simbolius! Ivesk iki kada galioja draudimas");
                    moto.InsuranceExp = Console.ReadLine();
                }
                insuranceExp = moto.InsuranceExp;
            }

            Console.Clear();
                Console.WriteLine("Duomenys sekmingai atnaujinti");
                Console.ReadKey();

            return new Tuple<string, string>(techServiceExp, insuranceExp);
        }

        // Motociklo grazinimas
        public bool MotoGivedBack(string vehNumber)
        {
            List<Motorcycle> motos = SqlQueries.SelectMotorcyclesWithClient();

            var result = motos.Select(m => m).Where(m => m.VehNumber == vehNumber);
            
            foreach (var bike in motos)
            {
                DateTime rentDay = Convert.ToDateTime(bike.RentFromDate);
                double days = (todayDate - rentDay).TotalDays;

                if (days == 0)
                {
                    totalPrice = bike.RentPrice;
                }
                else
                {
                    totalPrice = bike.RentPrice * days;
                }
            }
            moto.RentStatus = false;
            Console.Clear();
            Console.WriteLine($"Transporto priemone grazinta\nTransporto priemones kaina uz visa nuomos laikotarpi: {totalPrice} Eur");
            Console.ReadKey();

            return moto.RentStatus;
        }

        // Motociklo irasu isvedimas i ekkrana
        public void PrintAllMotoData()
        {
            List<Motorcycle> motos = SqlQueries.SelectMotorcycles();

            Console.Clear();
            Console.WriteLine("Numeris | Marke | Modelis | Variklis | Spalva | Metai | Nuomos kaina | TA | Draudimas\n");
            
            var result = motos.Select(m => m).OrderBy(m => m.Brand).ThenBy(m => m.Model);
            
            foreach (var moto in result)
            {
                Console.WriteLine($"{moto.VehNumber} | {moto.Brand} | {moto.Model} | {moto.Engine} | {moto.Color} | {moto.YearMade} | " +
                    $"{moto.RentPrice} | {moto.TechServiceExp} | {moto.InsuranceExp}");
            }
            Console.ReadKey();
        }

        // Galimu isnuomoti motociklu saraso isvedimas i ekrana
        public void AvailableMotosToRentData()
        {
            List<Motorcycle> motos = SqlQueries.SelectMotorcycles();

            Console.Clear();
            Console.WriteLine("Numeris | Marke | Modelis | Variklis | Spalva | Metai | Nuomos kaina | TA | Draudimas\n");

            var result = motos.Select(m => m).Where(m => m.RentStatus == false).OrderBy(m => m.Brand).ThenBy(m => m.Model);
            
            foreach (var moto in result)
            {
                DateTime dateTS = Convert.ToDateTime(moto.TechServiceExp);
                DateTime dateInsurance = Convert.ToDateTime(moto.InsuranceExp);
                int isTSValid = DateTime.Compare(dateTS, todayDate);
                int isInsuranceValid = DateTime.Compare(dateInsurance, todayDate);
                if (isTSValid >= 0 && isInsuranceValid >= 0)
                {
                    Console.WriteLine($"{moto.VehNumber} | {moto.Brand} | {moto.Model} | {moto.Engine} | {moto.Color} | {moto.YearMade} | " +
                    $"{moto.RentPrice} | {moto.TechServiceExp} | {moto.InsuranceExp}");
                }
            }
            Console.ReadKey();
        }

        // Isnuomotu motociklu isvedimas i ekrana
        public void RentedMotosData()
        {
            Console.Clear();
            Console.WriteLine("Numeris | Marke | Modelis | Variklis | Spalva | Metai | Nuomos kaina | TA | Draudimas\n");
            List<Motorcycle> motos = SqlQueries.SelectMotorcycles();
            var result = motos.Select(m => m).Where(m => m.RentStatus == true).OrderBy(m => m.Brand).ThenBy(m => m.Model);
            foreach (var moto in result)
            {
                Console.WriteLine($"{moto.VehNumber} | {moto.Brand} | {moto.Model} | {moto.Engine} | {moto.Color} | {moto.YearMade} | " +
                    $"{moto.RentPrice} | {moto.TechServiceExp} | {moto.InsuranceExp}");
            }
            Console.ReadKey();
        }

        // Motociklu su nebegaliojanciais ar baigianciais galioti dokumentais isvedimas i ekrana
        public void ValidDocsData()
        {
            Console.Clear();
            Console.WriteLine($"Numeris");
            Console.SetCursorPosition(10, 0);
            Console.WriteLine($"Marke");
            Console.SetCursorPosition(30, 0);
            Console.WriteLine($"Modelis");
            Console.SetCursorPosition(50, 0);
            Console.WriteLine($"TA");
            Console.SetCursorPosition(70, 0);
            Console.WriteLine($"Draudimas\n");
            List<Motorcycle> motos = SqlQueries.SelectMotorcycles();
            var result = motos.Select(m => m).OrderBy(m => m.Brand).ThenBy(m => m.Model);
            foreach (var moto in result)
            {
                // Datos konvertavimas i DateTime
                DateTime dateTS = Convert.ToDateTime(moto.TechServiceExp);
                DateTime dateInsurance = Convert.ToDateTime(moto.InsuranceExp);
                // Skaiciavimas kiek dienu liko iki TA ir draudimo galiojimo laiko pabaigos
                double isTSValid = (dateTS - todayDate).TotalDays;
                double isInsuranceValid = (dateInsurance - todayDate).TotalDays;
                // Patikrinimas ar TA ir draudimas dar galioja
                if (isTSValid < 0 && isInsuranceValid < 0)
                {
                    Console.SetCursorPosition(0, y);
                    Console.WriteLine($"{moto.VehNumber}");
                    Console.SetCursorPosition(10, y);
                    Console.WriteLine($"{moto.Brand}");
                    Console.SetCursorPosition(30, y);
                    Console.WriteLine($"{moto.Model}");
                    Console.SetCursorPosition(50, y);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{moto.TechServiceExp}");
                    Console.SetCursorPosition(70, y);
                    Console.WriteLine($"{moto.InsuranceExp}");
                    Console.ResetColor();
                    Console.SetCursorPosition(90, y);
                    y++;
                }
                else if (isTSValid < 0)
                {
                    Console.SetCursorPosition(0, y);
                    Console.WriteLine($"{moto.VehNumber}");
                    Console.SetCursorPosition(10, y);
                    Console.WriteLine($"{moto.Brand}");
                    Console.SetCursorPosition(30, y);
                    Console.WriteLine($"{moto.Model}");
                    Console.SetCursorPosition(50, y);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{moto.TechServiceExp}");
                    Console.ResetColor();
                    Console.SetCursorPosition(70, y);
                    Console.WriteLine($"{moto.InsuranceExp}");
                    Console.SetCursorPosition(90, y);
                    y++;
                }
                else if (isInsuranceValid < 0)
                {
                    Console.SetCursorPosition(0, y);
                    Console.WriteLine($"{moto.VehNumber}");
                    Console.SetCursorPosition(10, y);
                    Console.WriteLine($"{moto.Brand}");
                    Console.SetCursorPosition(30, y);
                    Console.WriteLine($"{moto.Model}");
                    Console.SetCursorPosition(50, y);
                    Console.WriteLine($"{moto.TechServiceExp}");
                    Console.SetCursorPosition(70, y);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{moto.InsuranceExp}");
                    Console.ResetColor();
                    Console.SetCursorPosition(90, y);
                    y++;
                }
                // Patikrinimas ar TA ir draudimas galioja daugiau nei 31 diena
                else if (isTSValid >= 0 && isTSValid < 32 && isInsuranceValid >= 0 && isInsuranceValid < 32)
                {
                    Console.SetCursorPosition(0, y);
                    Console.WriteLine($"{moto.VehNumber}");
                    Console.SetCursorPosition(10, y);
                    Console.WriteLine($"{moto.Brand}");
                    Console.SetCursorPosition(30, y);
                    Console.WriteLine($"{moto.Model}");
                    Console.SetCursorPosition(50, y);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{moto.TechServiceExp}");
                    Console.SetCursorPosition(70, y);
                    Console.WriteLine($"{moto.InsuranceExp}");
                    Console.SetCursorPosition(90, y);
                    Console.ResetColor();
                    y++;
                }
                else if (isTSValid >= 0 && isTSValid < 32)
                {
                    Console.SetCursorPosition(0, y);
                    Console.WriteLine($"{moto.VehNumber}");
                    Console.SetCursorPosition(10, y);
                    Console.WriteLine($"{moto.Brand}");
                    Console.SetCursorPosition(30, y);
                    Console.WriteLine($"{moto.Model}");
                    Console.SetCursorPosition(50, y);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{moto.TechServiceExp}");
                    Console.ResetColor();
                    Console.SetCursorPosition(70, y);
                    Console.WriteLine($"{moto.InsuranceExp}");
                    Console.SetCursorPosition(90, y);
                    y++;
                }
                else if (isInsuranceValid >= 0 && isInsuranceValid < 32)
                {
                    Console.SetCursorPosition(0, y);
                    Console.WriteLine($"{moto.VehNumber}");
                    Console.SetCursorPosition(10, y);
                    Console.WriteLine($"{moto.Brand}");
                    Console.SetCursorPosition(30, y);
                    Console.WriteLine($"{moto.Model}");
                    Console.SetCursorPosition(50, y);
                    Console.WriteLine($"{moto.TechServiceExp}");
                    Console.SetCursorPosition(70, y);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{moto.InsuranceExp}");
                    Console.ResetColor();
                    Console.SetCursorPosition(90, y);
                    y++;
                }
            }
            Console.ReadKey();
            y = 2;
        }

        // Isnuomoto motociklo paieska pagal motociklo numeri
        public void SearchByMoto(bool motoNumExist, string vehNumber)
        {
            if (motoNumExist)
            {
                Console.CursorVisible = false;
                List<Motorcycle> motos = SqlQueries.SelectMotorcyclesWithClient();
                List<Client> clients = SqlQueries.SelectClients();
                            Console.Clear();

                var result = (from m in motos
                              join cl in clients on m.ClientNumber equals cl.PersonalNumber
                              select new
                              {
                                  m.VehNumber,
                                  m.Brand,
                                  m.Model,
                                  cl.PersonalNumber,
                                  cl.Name,
                                  cl.Surename
                              }).Where(m => m.VehNumber == vehNumber);
                foreach (var moto in result)
                {
                    Console.WriteLine($"Motociklas: {moto.Brand} {moto.Model}\nNuomininkas: {moto.Name} {moto.Surename} " +
                        $"(a.k. {moto.PersonalNumber})");
                }
                Console.ReadKey();
            }
        }
    }
}
