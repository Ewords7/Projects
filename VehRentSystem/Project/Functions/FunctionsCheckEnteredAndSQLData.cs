using Project.Repository;
using Project.VehicleData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Project.Functions
{
    class FunctionsCheckEnteredAndSQLData
    {
        private bool isDataCorrect;
        private string vehNumber;
        private long personalNumber;
        private int bikeID;
        private bool comfirmedAction;
        private string choise;
        private string surename;
        private DateTime todaysDate = DateTime.Today;
        private SQLSelect SqlQueries = new SQLSelect();
        private SQLInsert sqlInsert = new SQLInsert();
        protected Regex lettersAndNums = new Regex("^[a-zA-Z0-9]*$");
        private Regex letters = new Regex("^[a-zA-Z]*$");
        public FunctionsCheckEnteredAndSQLData()
        {

        }

        // Patikrinimas ar transporto priemones numeris neegzistuoja
        public Tuple<bool, string> NotMatchingVehNumber()
        {
            List<Car> cars = SqlQueries.SelectCars();
            List<Motorcycle> motos = SqlQueries.SelectMotorcycles();

            Console.Clear();
            Console.CursorVisible = true;
            Console.WriteLine("Ivesk transporto priemones valstybini numeri");
            vehNumber = Console.ReadLine().ToUpper();
            while (!lettersAndNums.IsMatch(vehNumber) || vehNumber == "")
            {
                Console.WriteLine($"\nValstybini numeri gali sudaryti tik raides ir skaitmenys!\nIvesk transporto priemones valstybini numeri");
                vehNumber = Console.ReadLine().ToUpper();
            }
            var checkResultCars = cars.Select(c => c.VehNumber).Contains(vehNumber);
            var checkResultMotos = motos.Select(m => m.VehNumber).Contains(vehNumber);
            if (checkResultCars || checkResultMotos)
            {
                Console.Clear();
                Console.WriteLine("Transporto priemone su tokiu numeriu jau egzistuoja");
                Console.ReadKey();
                
                isDataCorrect = false;
            }
            else
            {
                isDataCorrect = true;
            }

            return new Tuple<bool, string>(isDataCorrect, vehNumber);
        }

        // Patikrinimas ar automobilio numeris egzistuoja
        public Tuple<bool, string> MatchingCarNumber()
        {
            List<Car> cars = SqlQueries.SelectCars();

            Console.Clear();
            Console.CursorVisible = true;
            Console.WriteLine("Ivesk automobilio valstybini numeri, kurio duomenis nori redaguoti");
            vehNumber = Console.ReadLine().ToUpper();
            while (!lettersAndNums.IsMatch(vehNumber) || vehNumber == "")
            {
                Console.WriteLine($"\nValstybini numeri gali sudaryti tik raides ir skaitmenys!\nIvesk automobilio valstybini numeri");
                vehNumber = Console.ReadLine().ToUpper();
            }
            var checkResult = cars.Select(c => c.VehNumber).Contains(vehNumber);
            if (!checkResult)
            {
                Console.Clear();
                Console.WriteLine("Automobilis su tokiu numeriu neegzistuoja");
                Console.ReadKey();
                
                isDataCorrect = false;
            }
            else
            {
                isDataCorrect = true;
            }

            return new Tuple<bool, string>(isDataCorrect, vehNumber);
        }

        // Patikrinimas ar isnuomoto automobilio numeris sutampa
        public virtual Tuple<bool, string> MatchingCarNumberWithClient()
        {
            List<Car> cars = SqlQueries.SelectCarsWithClient();

            Console.Clear();
            Console.CursorVisible = true;
            Console.WriteLine("Ivesk automobilio valstybini numeri");
            vehNumber = Console.ReadLine().ToUpper();
            while (!lettersAndNums.IsMatch(vehNumber) || vehNumber == "")
            {
                Console.WriteLine($"\nValstybini numeri gali sudaryti tik raides ir skaitmenys!\nIvesk automobilio valstybini numeri");
                vehNumber = Console.ReadLine().ToUpper();
            }
            var checkResult = cars.Select(c => c.VehNumber).Contains(vehNumber);
            if (!checkResult)
            {
                Console.Clear();
                Console.WriteLine("Automobilis su tokiu numeriu neegzistuoja arba nera isnuomotas");
                Console.ReadKey();
                
                isDataCorrect = false;
            }
            else
            {
                isDataCorrect = true;
            }

            return new Tuple<bool, string>(isDataCorrect, vehNumber);
        }

        // Patikrinimas ar automobilio numeris ir asmens kodas sutampa
        public Tuple<bool, string, long> MatchingCarNumberAndClientNumber()
        {

            List<Car> cars = SqlQueries.SelectCars();
            List<Client> clients = SqlQueries.SelectClients();

            Console.Clear();
            Console.CursorVisible = true;
            Console.WriteLine("Ivesk isnuomojamo automobilio valstybini numeri");
            vehNumber = Console.ReadLine().ToUpper();
            while (!lettersAndNums.IsMatch(vehNumber) || vehNumber == "")
            {
                Console.WriteLine($"\nValstybini numeri gali sudaryti tik raides ir skaitmenys!\nIvesk automobilio valstybini numeri");
                vehNumber = Console.ReadLine().ToUpper();
            }

            var prepareCheckList = cars.Select(c => c).Where(c => c.VehNumber == vehNumber && c.RentStatus == false &&
            Convert.ToDateTime(c.TechServiceExp) >= todaysDate && Convert.ToDateTime(c.InsuranceExp) >= todaysDate).ToList();
            var checkResult = prepareCheckList.Select(c => c.VehNumber).Contains(vehNumber);

            if (!checkResult)
            {
                Console.Clear();
                Console.WriteLine("Automobilis su tokiu numeriu neegzistuoja, yra isnuomotas arba neturi galiojanciu reikalingu dokumentu!");
                Console.ReadKey();
                
                isDataCorrect = false;
            }
            else
            {
                Console.WriteLine("Ivesk kliento asmens koda, kuriam isnuomojamas automobilis");
                while (!long.TryParse(Console.ReadLine(), out personalNumber))
                {
                    Console.WriteLine("\nAsmens koda sudaro tik skaitmenys! Ivesk kliento asmens koda");
                }

                var checkResult2 = clients.Select(cl => cl.PersonalNumber).Contains(personalNumber);

                if (!checkResult2)
                {                   
                    Console.Clear();
                    Console.WriteLine("Toks klientas neegzistuoja!\nJei nori prideti nauja klienta ivesk [Y], kitu atveju - [N]");
                    comfirmedAction = true;
                    while (comfirmedAction)
                    {
                        choise = Console.ReadLine().ToUpper();
                        if (choise == "Y")
                        {
                            sqlInsert.InsertClient(true, personalNumber);
                            isDataCorrect = true;
                            comfirmedAction = false;
                        }
                        else if (choise == "N")
                        {
                            isDataCorrect = false;
                            comfirmedAction = false;
                        }
                        else
                        {
                            Console.WriteLine("\nJei nori prideti nauja klienta ivesk [Y], kitu atveju - [N]");
                        }
                    }
                }
                else
                {
                    isDataCorrect = true;
                }
            }

            return new Tuple<bool, string, long>(isDataCorrect, vehNumber, personalNumber);
        }

        // Patikrinimas ar galima istrinti automobilio duomenis
        public Tuple<bool, string> AvailabilityDeleteCar()
        {
            List<Car> cars = SqlQueries.SelectCars();

            Console.Clear();
            Console.CursorVisible = true;
            Console.WriteLine("Ivesk automobilio numeri, kurio irasa nori pasalinti");
            vehNumber = Console.ReadLine().ToUpper();
            while (!lettersAndNums.IsMatch(vehNumber) || vehNumber == "")
            {
                Console.WriteLine($"\nValstybini numeri gali sudaryti tik raides ir skaitmenys!\nIvesk automobilio valstybini numeri");
                vehNumber = Console.ReadLine().ToUpper();
            }

            var prepareCheckResult = cars.Select(c => c).Where(c => c.VehNumber == vehNumber && c.RentStatus == false).ToList();
            var checkResult = prepareCheckResult.Select(c => c.VehNumber).Contains(vehNumber);
            
            if (!checkResult)
            {
                Console.Clear();
                Console.WriteLine("Automobilis su tokiu numeriu neegzistuoja arba yra isnuomotas");
                Console.ReadKey();
                
                isDataCorrect = false;
            }
            else
            {
                isDataCorrect = true;
                
                Console.Clear();
                Console.WriteLine("Automobilio duomenys sekmingai pasalinti");
                Console.ReadKey();
            }

            return new Tuple<bool, string>(isDataCorrect, vehNumber);
        }

        // Patikrinimas ar ivestas motociklo numeris sutampa
        public Tuple<bool, string> MatchingMotoNumber()
        {
            List<Motorcycle> motos = SqlQueries.SelectMotorcycles();

            Console.Clear();
            Console.CursorVisible = true;
            Console.WriteLine("Ivesk motociklo valstybini numeri, kurio duomenis nori redaguoti");
            vehNumber = Console.ReadLine().ToUpper();
            while (!lettersAndNums.IsMatch(vehNumber) || vehNumber == "")
            {
                Console.WriteLine($"\nValstybini numeri gali sudaryti tik raides ir skaitmenys!\nIvesk motociklo valstybini numeri");
                vehNumber = Console.ReadLine().ToUpper();
            }

            var checkResult = motos.Select(m => m.VehNumber).Contains(vehNumber);
            
            if (!checkResult)
            {
                Console.Clear();
                Console.WriteLine("Motociklas su tokiu numeriu neegzistuoja");
                Console.ReadKey();
                
                isDataCorrect = false;
            }
            else
            {
                isDataCorrect = true;
            }

            return new Tuple<bool, string>(isDataCorrect, vehNumber);
        }

        // Patikrinimas ar ivestas isnuomoto motociklo numeris sutampa
        public Tuple<bool, string> MatchingMotoNumberWithClient()
        {
            List<Motorcycle> motos = SqlQueries.SelectMotorcyclesWithClient();

            Console.Clear();
            Console.CursorVisible = true;
            Console.WriteLine("Ivesk motociklo valstybini numeri");
            vehNumber = Console.ReadLine().ToUpper();
            while (!lettersAndNums.IsMatch(vehNumber) || vehNumber == "")
            {
                Console.WriteLine($"\nValstybini numeri gali sudaryti tik raides ir skaitmenys!\nIvesk motociklo valstybini numeri");
                vehNumber = Console.ReadLine().ToUpper();
            }

            var checkResult = motos.Select(c => c.VehNumber).Contains(vehNumber);
            
            if (!checkResult)
            {
                Console.Clear();
                Console.WriteLine("Motociklas su tokiu numeriu neegzistuoja arba nera isnuomotas");
                Console.ReadKey();
                
                isDataCorrect = false;
            }
            else
            {
                isDataCorrect = true;
            }

            return new Tuple<bool, string>(isDataCorrect, vehNumber);
        }

        // Patikrinami ar ivesti motociklo numeris ir kliento kodas sutampa
        public Tuple<bool, string, long> MatchingMotoNumberAndPersonalNumber()
        {
            List<Motorcycle> motos = SqlQueries.SelectMotorcycles();
            List<Client> clients = SqlQueries.SelectClients();

            Console.Clear();
            Console.CursorVisible = true;
            Console.WriteLine("Ivesk isnuomojamo motociklo valstybini numeri");
            vehNumber = Console.ReadLine().ToUpper();
            while (!lettersAndNums.IsMatch(vehNumber) || vehNumber == "")
            {
                Console.WriteLine($"\nValstybini numeri gali sudaryti tik raides ir skaitmenys!\nIvesk motociklo valstybini numeri");
                vehNumber = Console.ReadLine().ToUpper();
            }

            var prepareCheckList = motos.Select(m => m).Where(m => m.VehNumber == vehNumber && m.RentStatus == false &&
            Convert.ToDateTime(m.TechServiceExp) >= todaysDate && Convert.ToDateTime(m.InsuranceExp) >= todaysDate).ToList();
            var checkResult = prepareCheckList.Select(m => m.VehNumber).Contains(vehNumber);
            
            if (!checkResult)
            {
                Console.Clear();
                Console.WriteLine("Motociklas su tokiu numeriu neegzistuoja, yra isnuomotas arba neturi galiojanciu reikalingu dokumentu!");
                Console.ReadKey();
                
                isDataCorrect = false;
            }
            else
            {
                Console.WriteLine("Ivesk kliento asmens koda, kuriam isnuomojamas motociklas");
                while (!long.TryParse(Console.ReadLine(), out personalNumber))
                {
                    Console.WriteLine("\nAsmens koda sudaro tik skaitmenys! Ivesk kliento asmens koda");
                }
                
                var checkResult2 = clients.Select(cl => cl.PersonalNumber).Contains(personalNumber);
                
                if (!checkResult2)
                {
                    Console.Clear();
                    Console.WriteLine("Toks klientas neegzistuoja!\nJei nori prideti nauja klienta ivesk [Y], kitu atveju - [N]");
                    comfirmedAction = true;
                    while (comfirmedAction)
                    {
                        choise = Console.ReadLine().ToUpper();
                        if (choise == "Y")
                        {
                            sqlInsert.InsertClient(true, personalNumber);
                            isDataCorrect = true;
                            comfirmedAction = false;
                        }
                        else if (choise == "N")
                        {
                            isDataCorrect = false;
                            comfirmedAction = false;
                        }
                        else
                        {
                            Console.WriteLine("\nJei nori prideti nauja klienta ivesk [Y], kitu atveju - [N]");
                        }
                    }
                }
                else
                {
                    isDataCorrect = true;
                }
            }

            return new Tuple<bool, string, long>(isDataCorrect, vehNumber, personalNumber);
        }

        // Patikrinimas ar galima istrinti motociklo duomenis
        public Tuple<bool, string> AvailabilityDeleteMoto()
        {
            List<Motorcycle> motos = SqlQueries.SelectMotorcycles();

            Console.Clear();
            Console.CursorVisible = true;
            Console.WriteLine("Ivesk motociklo numeri, kurio irasa nori pasalinti");
            vehNumber = Console.ReadLine().ToUpper();
            while (!lettersAndNums.IsMatch(vehNumber) || vehNumber == "")
            {
                Console.WriteLine($"\nValstybini numeri gali sudaryti tik raides ir skaitmenys!\nIvesk motociklo valstybini numeri");
                vehNumber = Console.ReadLine().ToUpper();
            }
            var prepareCheckResult = motos.Select(m => m).Where(m => m.VehNumber == vehNumber && m.RentStatus == false).ToList();
            var checkResult = prepareCheckResult.Select(m => m.VehNumber).Contains(vehNumber);
            if (!checkResult)
            {
                Console.Clear();
                Console.WriteLine("Motociklas su tokiu numeriu neegzistuoja arba yra isnuomotas");
                Console.ReadKey();
                
                isDataCorrect = false;
            }
            else
            {
                isDataCorrect = true;
                
                Console.Clear();
                Console.WriteLine("Motociklo duomenys sekmingai pasalinti");
                Console.ReadKey();
            }

            return new Tuple<bool, string>(isDataCorrect, vehNumber);
        }

        // Patikrinimas ar ivestas dviracio ID sutampa
        public Tuple<bool, int> CheckMatchingBikeID()
        {
            List<Bicycle> bikes = SqlQueries.SelectBikes();

            Console.Clear();
            Console.CursorVisible = true;
            Console.WriteLine("Ivesk dviracio ID");
            while (!int.TryParse(Console.ReadLine(), out bikeID))
            {
                Console.WriteLine("\nDviracio ID sudaro tik skaitmenys! Ivesk dviracio ID");
            }

            var checkResult = bikes.Select(b => b.BikeID).Contains(bikeID);
            
            if (!checkResult)
            {
                Console.Clear();
                Console.WriteLine("Dviratis su tokiu ID neegzistuoja!");
                Console.ReadKey();
                
                isDataCorrect = false;
            }
            else
            {
                isDataCorrect = true;
            }

            return new Tuple<bool, int>(isDataCorrect, bikeID);
        }

        // Patikrinami ar ivesti dviracio ID ir kliento asmens kodas sutampa
        public Tuple<bool, int, long> MatchingBikeIDAndClientNumber()
        {
            List<Bicycle> bikes = SqlQueries.SelectBikes();
            List<Client> clients = SqlQueries.SelectClients();

            Console.Clear();
            Console.CursorVisible = true;
            Console.WriteLine("Ivesk isnuomojamo dviracio ID");
            while (!int.TryParse(Console.ReadLine(), out bikeID))
            {
                Console.WriteLine("\nDviracio ID sudaro tik skaitmenys! Ivesk dviracio ID");
            }
            
            var prepareCheckList = bikes.Select(b => b).Where(b => b.BikeID == bikeID && b.RentStatus == false).ToList();
            var checkResult = prepareCheckList.Select(b => b.BikeID).Contains(bikeID);
            
            if (!checkResult)
            {
                Console.Clear();
                Console.WriteLine("Dviratis su tokiu ID neegzistuoja arba yra isnuomotas!");
                Console.ReadKey();
                
                isDataCorrect = false;
            }
            else
            {
                Console.WriteLine("Ivesk kliento asmens koda, kuriam isnuomojamas dviratis");
                while (!long.TryParse(Console.ReadLine(), out personalNumber))
                {
                    Console.WriteLine("\nAsmens koda sudaro tik skaitmenys! Ivesk kliento asmens koda");
                }
                
                var checkResult2 = clients.Select(cl => cl.PersonalNumber).Contains(personalNumber);
                
                if (!checkResult2)
                {
                    Console.Clear();
                    Console.WriteLine("Toks klientas neegzistuoja!\nJei nori prideti nauja klienta ivesk [Y], kitu atveju - [N]");
                    comfirmedAction = true;
                    while (comfirmedAction)
                    {
                        choise = Console.ReadLine().ToUpper();
                        if (choise == "Y")
                        {
                            sqlInsert.InsertClient(true, personalNumber);
                            isDataCorrect = true;
                            comfirmedAction = false;
                        }
                        else if (choise == "N")
                        {
                            isDataCorrect = false;
                            comfirmedAction = false;
                        }
                        else
                        {
                            Console.WriteLine("\nJei nori prideti nauja klienta ivesk [Y], kitu atveju - [N]");
                        }
                    }
                }
                else
                {
                    isDataCorrect = true;
                }
            }

            return new Tuple<bool, int, long>(isDataCorrect, bikeID, personalNumber);
        }

        // Patikrinimas ar ivestas isnuomoto dviracio ID sutampa
        public Tuple<bool, int> MatchingBikeIDWithClient()
        {
            List<Bicycle> bikes = SqlQueries.SelectBikesWithClient();

            Console.Clear();
            Console.CursorVisible = true;
            Console.WriteLine("Ivesk dviracio ID");
            while (!int.TryParse(Console.ReadLine(), out bikeID))
            {
                Console.WriteLine("\nDviracio ID sudaro tik skaitmenys! Ivesk dviracio ID");
            }
            
            var checkResult = bikes.Select(b => b.BikeID).Contains(bikeID);
            
            if (!checkResult)
            {
                Console.Clear();
                Console.WriteLine("Dviratis su tokiu ID neegzistuoja arba nera isnuomotas!");
                Console.ReadKey();
                
                isDataCorrect = false;
            }
            else
            {
                isDataCorrect = true;
            }

            return new Tuple<bool, int>(isDataCorrect, bikeID);
        }

        // Patikrinimas ar galima istrinti dviracio duomenis
        public Tuple<bool, int> AvailabilityDeleteBike()
        {
            List<Bicycle> bikes = SqlQueries.SelectBikes();

            Console.Clear();
            Console.CursorVisible = true;

            Console.WriteLine("Ivesk dviracio ID, kurio irasa nori panaikinti");
            while (!int.TryParse(Console.ReadLine(), out bikeID))
            {
                Console.WriteLine("\nDviracio ID sudaro tik skaitmenys! Ivesk dviracio ID");
            }
            var prepareCheckResult = bikes.Select(b => b).Where(b => b.BikeID == bikeID && b.RentStatus == false);
            var checkResult = prepareCheckResult.Select(b => b.BikeID).Contains(bikeID);
            if (!checkResult)
            {
                Console.Clear();
                Console.WriteLine("Dviratis su tokiu ID neegzistuoja arba yra isnuomotas!");
                Console.ReadKey();
                
                isDataCorrect = false;
            }
            else
            {
                isDataCorrect = true;
                
                Console.Clear();
                Console.WriteLine($"Duomenys apie dvirati sekmingai pasalinti");
                Console.ReadKey();
            }

            return new Tuple<bool, int>(isDataCorrect, bikeID);
        }

        // Patikrinimas ar ivestas kliento asmens kodas neegzistuoja
        public Tuple<bool, long> NotMatchingPersonalNumber()
        {
            List<Client> clients = SqlQueries.SelectClients();

            Console.Clear();
            Console.CursorVisible = true;
            Console.WriteLine("Ivesk asmens koda");
            while (!long.TryParse(Console.ReadLine(), out personalNumber))
            {
                Console.WriteLine("Asmens koda turi sudaryti tik skaitmenys!\nIvesk asmens koda");
            }

            var checkResult = clients.Select(cl => cl.PersonalNumber).Contains(personalNumber);
            
            if (checkResult)
            {
                Console.Clear();
                Console.WriteLine("Klientas su tokiu asmens kodu jau egzistuoja!");
                Console.ReadKey();
                
                isDataCorrect = false;
            }
            else
            {
                isDataCorrect = true;
            }

            return new Tuple<bool, long>(isDataCorrect, personalNumber);
        }

        // Patikrinimas ar ivestas asmens kodas egzistuoja
        public Tuple<bool, long> MathchingPersonalNumber()
        {
            List<Client> clients = SqlQueries.SelectClients();

            Console.Clear();
            Console.CursorVisible = true;
            Console.WriteLine("Ivesk kliento asmens koda, kurio duomenis nori redaguoti");
            while (!long.TryParse(Console.ReadLine(), out personalNumber))
            {
                Console.WriteLine("Asmens koda turi sudaryti tik skaitmenys!\nIvesk asmens koda");
            }

            var checkResult = clients.Select(cl => cl.PersonalNumber).Contains(personalNumber);
            
            if (!checkResult)
            {
                Console.Clear();
                Console.WriteLine("Klientas su tokiu asmens kodu negzistuoja!");
                Console.ReadKey();
                
                isDataCorrect = false;
            }
            else
            {
                isDataCorrect = true;
            }

            return new Tuple<bool, long>(isDataCorrect, personalNumber);
        }

        // Patikrinimas ar ivesta kliento pavarde egzistuoja
        public Tuple<bool, string> MathchingClientSurename()
        {
            List<Client> clients = SqlQueries.SelectClients();

            Console.Clear();
            Console.CursorVisible = true;
            Console.WriteLine("Ivesk kliento pavarde");
            surename = Console.ReadLine();
            if (surename != "")
            {
                surename = char.ToUpper(surename[0]) + surename.Substring(1);
            }

            while (!letters.IsMatch(surename) || surename == "")
            {
                Console.WriteLine($"\nPavarde gali sudaryti tik raides!\nIvesk kliento pavarde");
                surename = Console.ReadLine();
                if (surename != "")
                {
                    surename = char.ToUpper(surename[0]) + surename.Substring(1);
                }
            }
            var checkResult = clients.Select(cl => cl.Surename).Contains(surename);
            if (!checkResult)
            {
                Console.Clear();
                Console.WriteLine("Klientas su tokia pavarde neegzistuoja!");
                Console.ReadKey();
                
                isDataCorrect = false;
            }
            else
            {
                isDataCorrect = true;
            }

            return new Tuple<bool, string>(isDataCorrect, surename);
        }

        // Patikrinimas ar galima istrinti kliento duomenis
        public Tuple<bool, long> AvailabilityDeleteClient()
        {
            List<Car> carsWithClient = SqlQueries.SelectCarsWithClient();
            List<Motorcycle> motosWithClient = SqlQueries.SelectMotorcyclesWithClient();
            List<Bicycle> bikesWithClient = SqlQueries.SelectBikesWithClient();
            List<Client> clients = SqlQueries.SelectClients();

            Console.Clear();
            Console.CursorVisible = true;
            Console.WriteLine("Ivesk kliento, kuri nori pasalinti is sistemos, asmens koda");
            while (!long.TryParse(Console.ReadLine(), out personalNumber))
            {
                Console.WriteLine("Asmens koda turi sudaryti tik skaitmenys!\nIvesk asmens koda");
            }

            var checkResultClient = clients.Select(cl => cl.PersonalNumber).Contains(personalNumber);
            var checkResultCar = carsWithClient.Select(c => c.ClientNumber).Contains(personalNumber);
            var checkResultMoto = motosWithClient.Select(m => m.ClientNumber).Contains(personalNumber);
            var checkResultBike = bikesWithClient.Select(b => b.ClientNumber).Contains(personalNumber);
            
            if (!checkResultClient)
            {
                Console.Clear();
                Console.WriteLine("Klientas su tokiu asmens kodu negzistuoja!");
                Console.ReadKey();
                
                isDataCorrect = false;
            }
            else
            {
                if (checkResultCar || checkResultMoto || checkResultBike)
                {
                    Console.Clear();
                    Console.WriteLine("Kliento duomenys negali buti panaikinti, nes jis yra issinuomaves transporto priemone!");
                    Console.ReadKey();
                    
                    isDataCorrect = false;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Klientas sekmingai pasalintas is sistemos");
                    Console.ReadKey();
                    
                    isDataCorrect = true;
                }
            }

            return new Tuple<bool, long>(isDataCorrect, personalNumber);
        }
    }
}
