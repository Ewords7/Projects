using Project.SQLQueries;
using Project.VehicleData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Project.Functions
{
    class ClientManagement
    {
        private int y = 2;
        private double? totalRentPrice;
        private DateTime todaysDate = DateTime.Today;
        private SQLSelect SqlQueries = new SQLSelect();
        private Client client = new Client();
        private Regex letters = new Regex("^[a-zA-Z/]*$");
        private Regex date = new Regex("^[0-9.-]*$");
        private Regex address = new Regex("^[a-zA-Z0-9- ]*$");

        public ClientManagement()
        {

        }

        // Kliento iraso pridejimas su ivedimo patikrinimu
        public Client AddClient()
        {
            Console.WriteLine("\nIvesk kliento varda");
            client.Name = Console.ReadLine();
            // Pirmosios vardo raides keitimas i didziaja
            if (client.Name != "")
            {
                client.Name = char.ToUpper(client.Name[0]) + client.Name.Substring(1);
            }
            while (!letters.IsMatch(client.Name) || client.Name == "")
            {
                Console.WriteLine("Ivedimui reikia naudoti raides!\nIvesk kliento varda");
                client.Name = Console.ReadLine();
                // Pirmosios vardo raides keitimas i didziaja
                if (client.Name != "")
                {
                    client.Name = char.ToUpper(client.Name[0]) + client.Name.Substring(1);
                }
            }

            Console.WriteLine("\nIvesk kliento pavarde");
            client.Surename = Console.ReadLine();
            // Pirmosios pavardes raides keitimas i didziaja
            client.Surename = char.ToUpper(client.Surename[0]) + client.Surename.Substring(1);
            while (!letters.IsMatch(client.Surename) || client.Surename == "")
            {
                Console.WriteLine("Ivedimui reikia naudoti raides!\nIvesk kliento pavarde");
                client.Surename = Console.ReadLine();
                // Pirmosios pavardes raides keitimas i didziaja
                client.Surename = char.ToUpper(client.Surename[0]) + client.Surename.Substring(1);
            }

            Console.WriteLine("\nIvesk gimimo data");
            client.DateOfBirth = Console.ReadLine();
            while (!date.IsMatch(client.DateOfBirth) || client.DateOfBirth == "")
            {
                Console.WriteLine("Ivedimui galima naudoti tik skaicius ir tasko (.) arba bruksnio (-) simbolius!" +
                    "\nIvesk kliento gimimo data");
                client.DateOfBirth = Console.ReadLine();
            }

            Console.WriteLine("\nIvesk adresa (gatve, namo ir buto numeris)");
            client.Address = Console.ReadLine();
            while (!address.IsMatch(client.Address) || client.Address == "")
            {
                Console.WriteLine("Naudojami neleistini simboliai!\nIvesk kliento adresa");
                client.Address = Console.ReadLine();
            }

            Console.WriteLine("\nIvesk miesta");
            client.City = Console.ReadLine();
            while (!letters.IsMatch(client.City) || client.City == "")
            {
                Console.WriteLine("Ivedimui reikia naudoti raides!\nIvesk miesta");
                client.City = Console.ReadLine();
            }

            Console.Clear();
            Console.WriteLine("Klientas sekmingai ivestas i sistema");
            Console.ReadKey();

            return new Client(client.PersonalNumber, client.Name, client.Surename, client.DateOfBirth, client.Address, client.City);
        }

        // Kliento tam tikru duomenu redagavimas su ivedimo patikrinimu
        public Tuple<string, string> EditData()
        {
            Console.WriteLine("\nIvesk adresa (gatve, namo ir buto numeris)");
            client.Address = Console.ReadLine();
            while (!address.IsMatch(client.Address) || client.Address == "")
            {
                Console.WriteLine("Naudojami neleistini simboliai!\nIvesk kliento adresa");
                client.Address = Console.ReadLine();
            }

            Console.WriteLine("\nIvesk miesta");
            client.City = Console.ReadLine();
            while (!letters.IsMatch(client.City) || client.City == "")
            {
                Console.WriteLine("Ivedimui reikia naudoti raides!\nIvesk miesta");
                client.City = Console.ReadLine();
            }

            Console.Clear();
            Console.WriteLine("Kliento duomenys sekmingai pakoreguoti");
            Console.ReadKey();

            return new Tuple<string, string>(client.Address, client.City);
        }

        // Kliento duomenu isvedimas i ekrana
        public void ClientData()
        {
            
            List<Client> clients = SqlQueries.SelectClients();
            
            Console.Clear();            
            Console.WriteLine($"AK");
            Console.SetCursorPosition(15, 0);
            Console.WriteLine($"Vardas");
            Console.SetCursorPosition(30, 0);
            Console.WriteLine($"Pavarde");
            Console.SetCursorPosition(50, 0);
            Console.WriteLine($"Gimimo data");
            Console.SetCursorPosition(70, 0);
            Console.WriteLine($"Adresas");
            Console.SetCursorPosition(90, 0);
            Console.WriteLine($"Miestas");
            Console.SetCursorPosition(110, 0);

            var result = clients.Select(cl => cl).OrderBy(cl => cl.Name).ThenBy(cl => cl.Surename);

            foreach (var client in result)
            {
                Console.SetCursorPosition(0, y);
                Console.WriteLine(client.PersonalNumber);
                Console.SetCursorPosition(15, y);
                Console.WriteLine(client.Name);
                Console.SetCursorPosition(30, y);
                Console.WriteLine(client.Surename);
                Console.SetCursorPosition(50, y);
                Console.WriteLine(client.DateOfBirth);
                Console.SetCursorPosition(70, y);
                Console.WriteLine(client.Address);
                Console.SetCursorPosition(90, y);
                Console.WriteLine(client.City);
                Console.SetCursorPosition(110, y);
                y++;
            }

            Console.ReadKey();
            // Atstatoma y reiksme
            y = 2;
        }

        // Isnuomotu transporto priemoniu konkreciam klientui gavimas pagal kliento asmens koda
        public void VehiclesRentedToClient(bool personalNumExist, long personalNumber)
        {
            if (personalNumExist)
            {
                // Pradines nuomu kainu reiksmes
                double? rentPriceForCar = 0;
                double? rentPriceForMoto = 0;
                double? rentPriceForBike = 0;
                List<Client> clients = SqlQueries.SelectClients();
                List<Car> cars = SqlQueries.SelectCarsWithClient();
                List<Motorcycle> motos = SqlQueries.SelectMotorcyclesWithClient();
                List<Bicycle> bikes = SqlQueries.SelectBikesWithClient();

                Console.CursorVisible = false;
                Console.Clear();

                // Kliento gavimas
                var result = clients.Select(cl => cl).Where(cl => cl.PersonalNumber == personalNumber);

                foreach (var client in result)
                {
                    Console.WriteLine($"Klientas: {client.Name} {client.Surename} (a.k.: {personalNumber})\n");
                }

                Console.WriteLine("Automobiliai\n");

                // Automobilio gavimas
                var result2 = cars.Select(c => c).Where(c => c.ClientNumber == personalNumber).OrderBy(c => c.Brand).ThenBy(c => c.Model);
                foreach (var car in result2)
                {
                    // Skaiciavimas kiek dienu isnuomotas automobilis
                    DateTime rentDay = Convert.ToDateTime(car.RentFromDate);
                    double daysRented = (todaysDate - rentDay).TotalDays;

                    if (daysRented == 0)
                    {
                        // Nuomos kaina, jei automobilis isnuomotas siandien
                        rentPriceForCar += car.RentPrice;
                    }
                    else
                    {
                        // Nuomos kaina, jei automobilis isnuomotas seniau nei siandien
                        rentPriceForCar += car.RentPrice * daysRented;
                    }

                    Console.WriteLine($"{car.VehNumber} {car.Brand} {car.Model}");
                }

                Console.WriteLine("\nMotociklai\n");

                // Motociklo gavimas
                var result3 = motos.Select(m => m).Where(m => m.ClientNumber == personalNumber).OrderBy(m => m.Brand).ThenBy(m => m.Model);

                foreach (var moto in result3)
                {
                    // Skaiciavimas kiek dienu isnuomotas motociklas
                    DateTime rentDay = Convert.ToDateTime(moto.RentFromDate);
                    double daysRented = (todaysDate - rentDay).TotalDays;

                    if (daysRented == 0)
                    {
                        // Nuomos kaina, jei motociklas isnuomotas siandien
                        rentPriceForMoto += moto.RentPrice;
                    }
                    else
                    {
                        // Nuomos kaina, jei motociklas isnuomotas seniau nei siandien
                        rentPriceForMoto += moto.RentPrice * daysRented;
                    }

                    Console.WriteLine($"{moto.VehNumber} | {moto.Brand} | {moto.Model}");
                }

                Console.WriteLine("\nDviraciai\n");

                // Dviracio gavimas
                var result4 = bikes.Select(b => b).Where(b => b.ClientNumber == personalNumber).OrderBy(b => b.Brand).ThenBy(b => b.Model);

                foreach (var bike in result4)
                {
                    // Skaiciavimas kiek dienu isnuomotas dviratis
                    DateTime rentDay = Convert.ToDateTime(bike.RentFromDate);
                    double daysRented = (todaysDate - rentDay).TotalDays;

                    if (daysRented == 0)
                    {
                        // Nuomos kaina, jei dviratis isnuomotas siandien
                        rentPriceForBike += bike.RentPrice;
                    }
                    else
                    {
                        // Nuomos kaina, jei dviratis isnuomotas seniau nei siandien
                        rentPriceForBike += bike.RentPrice * daysRented;
                    }

                    Console.WriteLine($"{bike.BikeID} | {bike.Brand} | {bike.Model}");
                }

                totalRentPrice = (rentPriceForCar + rentPriceForMoto + rentPriceForBike);

                Console.WriteLine($"\n\n\nSusikaupusi nuomos kaina uz issinuomotus automobilius: {rentPriceForCar} Eur.\n" +
                    $"Susikaupusi nuomos kaina uz issinuomotus motociklus: {rentPriceForMoto} Eur.\n" +
                    $"Susikaupusi nuomos kaina uz issinuomotus dviracius: {rentPriceForBike} Eur.\n" +
                    $"\nSusikaupusi nuomos kaina uz visas issinuomotas transporto priemones: {totalRentPrice} Eur.");

                Console.ReadKey();
            }
        }

        // Asmens kodo paieska pagal pavarde
        public void SearchBySurename(bool surenameExist, string surename)
        {
            if (surenameExist)
            {
                List<Client> clients = SqlQueries.SelectClients();

                Console.CursorVisible = false;
                Console.Clear();
                
                Console.WriteLine($"AK");
                Console.SetCursorPosition(15, 0);
                Console.WriteLine($"Vardas");
                Console.SetCursorPosition(30, 0);
                Console.WriteLine($"Pavarde");
                Console.SetCursorPosition(30, 0);

                var result = clients.Select(cl => cl).Where(cl => cl.Surename == surename);

                foreach (var client in result)
                {
                    Console.SetCursorPosition(0, y);
                    Console.WriteLine(client.PersonalNumber);
                    Console.SetCursorPosition(15, y);
                    Console.WriteLine(client.Name);
                    Console.SetCursorPosition(30, y);
                    Console.WriteLine(client.Surename);
                    y++;
                }

                Console.ReadKey();
                // Atstatoma y reiksme
                y = 2;
            }
        }
    }
}
