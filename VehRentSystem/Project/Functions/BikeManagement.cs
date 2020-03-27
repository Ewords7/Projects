using Project.Repository;
using Project.VehicleData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Project.Functions
{
    class BikeManagement
    {
        private int y = 2;
        private double? totalPrice;
        private DateTime todayDate = DateTime.Today;
        private SQLSelect SqlQueries = new SQLSelect();
        private Bicycle bike = new Bicycle();
        private Regex letters = new Regex("^[a-zA-Z/]*$");
        private Regex doubleNumbers = new Regex("^[0-9.]*$");
        public string tempRentPrice { get; set; }

        public BikeManagement()
        {

        }

        // Dviracio iraso kurimas su ivedimo patikrinimu
        public Bicycle MakeBikeRecord()
        {
            Console.Clear();
            Console.CursorVisible = true;

            Console.WriteLine("Ivesk dviracio pavadinima");
            bike.Brand = Console.ReadLine();
            while (bike.Brand == "")
            {
                Console.WriteLine($"\nNeivestas dviracio pavadinimas!\nIvesk dviracio pavadinima");
                bike.Brand = Console.ReadLine();
            }

            Console.WriteLine("\nIvesk dviracio modeli");
            bike.Model = Console.ReadLine();
            while (bike.Model == "")
            {
                Console.WriteLine($"\nNeivestas dviracio modelis!\nIvesk dviracio modeli");
                bike.Model = Console.ReadLine();
            }

            Console.WriteLine("\nIvesk dviracio spalva");
            bike.Color = Console.ReadLine();
            while (!letters.IsMatch(bike.Color))
            {
                Console.WriteLine("\nIvesti gali tik raides! Ivesk spalva is naujo");
                bike.Color = Console.ReadLine();
            }

            Console.WriteLine("\nIvesk dviracio nuomos kaina parai");
            tempRentPrice = Console.ReadLine();
            while (!doubleNumbers.IsMatch(tempRentPrice) || tempRentPrice == "")
            {
                Console.WriteLine("\nNuomos kainai ivesti naudok tik skaicius ir tasko(.) simboli! Ivesk nuomos kaina is naujo");
                tempRentPrice = Console.ReadLine();
            }
            bike.RentPrice = Convert.ToDouble(tempRentPrice);

            Console.Clear();
            Console.WriteLine("Dviratis sekmingai pridetas i sistema");
            Console.ReadKey();

            return new Bicycle(bike.BikeID, bike.ClientNumber, bike.Brand, bike.Model, bike.Color, bike.RentPrice,
                bike.RentStatus);
        }

        // Dviracio duomenu redagavimas su ivedimo patikrinimu
        public double? EditData()
        {
            Console.WriteLine("\nIvesk dviracio nuomos kaina");
            tempRentPrice = Console.ReadLine();
            while (!doubleNumbers.IsMatch(tempRentPrice) || tempRentPrice == "")
            {
                Console.WriteLine("\nNuomos kainai ivesti naudok tik skaicius ir tasko(.) simboli! Ivesk nuomos kaina is naujo");
                tempRentPrice = Console.ReadLine();
            }
            bike.RentPrice = Convert.ToDouble(tempRentPrice);
            Console.Clear();
            Console.WriteLine("Duomenys sekmingai pakoreguoti");
            Console.ReadKey();

            return bike.RentPrice;
        }

        // Dviracio duomenu isvedimas i ekrana
        public void PrintAllData()
        {
            List<Bicycle> bikes = SqlQueries.SelectBikes();

            Console.Clear();
            Console.WriteLine($"ID");
            Console.SetCursorPosition(10, 0);
            Console.WriteLine($"Pavadinimas");
            Console.SetCursorPosition(30, 0);
            Console.WriteLine($"Modelis");
            Console.SetCursorPosition(50, 0);
            Console.WriteLine($"Spalva");
            Console.SetCursorPosition(70, 0);
            Console.WriteLine($"Nuomos kaina");
            
            var result = bikes.Select(s => s).OrderBy(b => b.Brand).ThenBy(b => b.Model);

            foreach (var bike in result)
            {
                Console.SetCursorPosition(0, y);
                Console.WriteLine($"{bike.BikeID}");
                Console.SetCursorPosition(10, y);
                Console.WriteLine($"{bike.Brand}");
                Console.SetCursorPosition(30, y);
                Console.WriteLine($"{bike.Model}");
                Console.SetCursorPosition(50, y);
                Console.WriteLine($"{bike.Color}");
                Console.SetCursorPosition(70, y);
                Console.WriteLine($"{bike.RentPrice}");
                Console.SetCursorPosition(90, y);
                y++;
            }

            Console.ReadKey();
            // Atstatoma y reiksme
            y = 2;
        }

        // Galimu isnuomoti dviraciu isvedimas i ekrana
        public void AvailableBikesToRentData()
        {

            List<Bicycle> bikes = SqlQueries.SelectBikes();

            Console.Clear();
            Console.WriteLine($"ID");
            Console.SetCursorPosition(10, 0);
            Console.WriteLine($"Pavadinimas");
            Console.SetCursorPosition(30, 0);
            Console.WriteLine($"Modelis");
            Console.SetCursorPosition(50, 0);
            Console.WriteLine($"Spalva");
            Console.SetCursorPosition(70, 0);
            Console.WriteLine($"Nuomos kaina");

            var result = bikes.Select(b => b).Where(b => b.RentStatus == false).OrderBy(b => b.Brand).ThenBy(b => b.Model);

            foreach (var bike in result)
            {
                Console.SetCursorPosition(0, y);
                Console.WriteLine($"{bike.BikeID}");
                Console.SetCursorPosition(10, y);
                Console.WriteLine($"{bike.Brand}");
                Console.SetCursorPosition(30, y);
                Console.WriteLine($"{bike.Model}");
                Console.SetCursorPosition(50, y);
                Console.WriteLine($"{bike.Color}");
                Console.SetCursorPosition(70, y);
                Console.WriteLine($"{bike.RentPrice}");
                Console.SetCursorPosition(90, y);
                y++;
            }

            Console.ReadKey();
            // Atstatoma y reiksme
            y = 2;
        }

        // Isnuomotu dviraciu isvedimas i ekrana
        public void RentedBikesData()
        {
            List<Bicycle> bikes = SqlQueries.SelectBikes();

            Console.Clear();
            Console.WriteLine($"ID");
            Console.SetCursorPosition(10, 0);
            Console.WriteLine($"Pavadinimas");
            Console.SetCursorPosition(30, 0);
            Console.WriteLine($"Modelis");
            Console.SetCursorPosition(50, 0);
            Console.WriteLine($"Spalva");
            Console.SetCursorPosition(70, 0);
            Console.WriteLine($"Nuomos kaina");

            var result = bikes.Select(b => b).Where(b => b.RentStatus == true).OrderBy(b => b.Brand).ThenBy(b => b.Model);

            foreach (var bike in result)
            {
                Console.SetCursorPosition(0, y);
                Console.WriteLine($"{bike.BikeID}");
                Console.SetCursorPosition(10, y);
                Console.WriteLine($"{bike.Brand}");
                Console.SetCursorPosition(30, y);
                Console.WriteLine($"{bike.Model}");
                Console.SetCursorPosition(50, y);
                Console.WriteLine($"{bike.Color}");
                Console.SetCursorPosition(70, y);
                Console.WriteLine($"{bike.RentPrice}");
                Console.SetCursorPosition(90, y);
                y++;
            }

            Console.ReadKey();
            // Atstatoma y reiksme
            y = 2;
        }

        // Isnuomoto dviracio ir nuomininko paieska pagal dviracio ID
        public void SearchByBikeID(bool bikeIDExist, int bikeID)
        {
            if (bikeIDExist)
            {
                List<Bicycle> bikes = SqlQueries.SelectBikesWithClient();
                List<Client> clients = SqlQueries.SelectClients();

                Console.CursorVisible = false;
                Console.Clear();

                var result = (from b in bikes
                              join cl in clients on b.ClientNumber equals cl.PersonalNumber
                              select new
                              {
                                  b.BikeID,
                                  b.Brand,
                                  b.Model,
                                  cl.PersonalNumber,
                                  cl.Name,
                                  cl.Surename
                              }).Where(b => b.BikeID == bikeID);
                foreach (var bike in result)
                {
                    Console.WriteLine($"Dviratis: {bike.Brand} {bike.Model}\nNuomininkas: {bike.Name} {bike.Surename} " +
                        $"(a.k. {bike.PersonalNumber})");
                }
                Console.ReadKey();
            }
        }

        // Dviracio grazinimas
        public bool BikeGivedBack(int bikeID)
        {
            List<Bicycle> bikes = SqlQueries.SelectBikesWithClient();
            var result = bikes.Select(b => b).Where(b => b.BikeID == bikeID);
            foreach (var bike in bikes)
            {
                // Skaiciavimas kiek dienu buvo isnuomotas dviratis
                DateTime rentDay = Convert.ToDateTime(bike.RentFromDate);
                double days = (todayDate - rentDay).TotalDays;

                if (days == 0)
                {
                    // Nuomos kaina, jei dviratis grazinamas ta pacia diena
                    totalPrice = bike.RentPrice;
                }
                else
                {
                    // Pilnos nuomos kainos skaiciavimas
                    totalPrice = bike.RentPrice * days;
                }
            }

            bike.RentStatus = false;

            Console.Clear();
            Console.WriteLine($"Transporto priemone grazinta\nTransporto priemones kaina uz visa nuomos laikotarpi: {totalPrice} Eur");
            Console.ReadKey();

            return bike.RentStatus;
        }
    }
}
