using ND4.GuiMenu;
using Project.Functions;
using Project.GuiMenu;
using Project.SQLQueries;
using Project.VehicleData;
using System;

namespace les9_game.GuiMenu
{
    class GuiController
    {
        private MainMenu mainMenu;
        private AdministrationMenu administrationMenu;
        private VehicleMenuToAddData vehicleMenuToAddData;
        private DataEditingMenu dataEditingMenu;
        private DataDeleteMenu dataDeleteMenu;
        private RentMenu rentMenu;
        private GetInfoMenu getInfoMenu;
        private SearchInfoMenu searchInfoMenu;
        private FunctionsCheckEnteredAndSQLData functionsForSQL;
        private BikeManagement functionsForBike;
        private CarManagement functionsForCar;
        private MotoManagement functionsForMoto;
        private ClientManagement functionsForClient;
        private SQLInsert sqlInsert;
        private SQLEdit sqlEdit;
        private SQLDelete sqlDelete;
        public GuiController()
        {
            mainMenu = new MainMenu();
            administrationMenu = new AdministrationMenu();
            vehicleMenuToAddData = new VehicleMenuToAddData();
            dataEditingMenu = new DataEditingMenu();
            dataDeleteMenu = new DataDeleteMenu();
            rentMenu = new RentMenu();
            getInfoMenu = new GetInfoMenu();
            searchInfoMenu = new SearchInfoMenu();
            functionsForSQL = new FunctionsCheckEnteredAndSQLData();
            functionsForBike = new BikeManagement();
            functionsForCar = new CarManagement();
            functionsForMoto = new MotoManagement();
            functionsForClient = new ClientManagement();
            sqlInsert = new SQLInsert();
            sqlEdit = new SQLEdit();
            sqlDelete = new SQLDelete();
        }

        // Pagrindinio meniu valdymas
        public void ShowMenu()
        {
            bool needToRender = true;
            while (needToRender)
            {
                mainMenu.Render();
                ConsoleKeyInfo pressedChar = Console.ReadKey(true);
                switch (pressedChar.Key)
                {
                    case ConsoleKey.D1:
                        AdministrationSelectionMenu();
                        break;
                    case ConsoleKey.D2:
                        GetInfoSelectionMenu();
                        break;
                    case ConsoleKey.D3:
                        SearchInfoSlectionMenu();
                        break;
                    case ConsoleKey.Escape:
                        Console.Clear();
                        Environment.Exit(0);
                        break;
                }
            } 
            Console.Clear();
        }

        // Administravimo meniu valdymas
        public void AdministrationSelectionMenu()
        {
            bool needToRender = true;
            while (needToRender)
            {
                administrationMenu.Render();
                ConsoleKeyInfo pressedChar = Console.ReadKey(true);
                switch (pressedChar.Key)
                {
                    case ConsoleKey.D1:
                        AddDataMenuSelection();
                        break;
                    case ConsoleKey.D2:
                        EditingMenuSelection();
                        break;
                    case ConsoleKey.D3:
                        DeleteMenuSelection();
                        break;
                    case ConsoleKey.D4:
                        RentMenuSelection();
                        break;
                    case ConsoleKey.Backspace:
                        Console.Clear();
                        ShowMenu();
                        break;
                    case ConsoleKey.Escape:
                        Console.Clear();
                        Environment.Exit(0);
                        break;
                }
            }
            Console.Clear();
        }

        // Duomenu ivedimo meniu valdymas
        public void AddDataMenuSelection()
        {
            bool needToRender = true;
            while (needToRender)
            {                
                vehicleMenuToAddData.Render();
                ConsoleKeyInfo pressedChar = Console.ReadKey(true);
                switch (pressedChar.Key)
                {
                    case ConsoleKey.D1:
                        var checkVehNumberCar = functionsForSQL.NotMatchingVehNumber();
                        sqlInsert.InsertCar(checkVehNumberCar.Item1, checkVehNumberCar.Item2);
                        break;
                    case ConsoleKey.D2:
                        var checkVehNumberMoto = functionsForSQL.NotMatchingVehNumber();
                        sqlInsert.InsertMoto(checkVehNumberMoto.Item1, checkVehNumberMoto.Item2);
                        break;
                    case ConsoleKey.D3:
                        sqlInsert.InsertBike();
                        break;
                    case ConsoleKey.D4:
                        var checkClientPersonalNumber = functionsForSQL.NotMatchingPersonalNumber();
                        sqlInsert.InsertClient(checkClientPersonalNumber.Item1, checkClientPersonalNumber.Item2);
                        break;
                    case ConsoleKey.Backspace:
                        Console.Clear();
                        ShowMenu();
                        break;
                    case ConsoleKey.Escape:
                        Console.Clear();
                        Environment.Exit(0);
                        break;
                }
            }
        }

        // Duomenu redagavimo meniu valdymas
        public void EditingMenuSelection()
        {
            bool needToRender = true;
            while (needToRender)
            {
                dataEditingMenu.Render();
                ConsoleKeyInfo pressedChar = Console.ReadKey(true);
                switch (pressedChar.Key)
                {
                    case ConsoleKey.D1:
                        var machingCarNumber = functionsForSQL.MatchingCarNumber();
                        sqlEdit.EditCarData(machingCarNumber.Item1, machingCarNumber.Item2);
                        break;
                    case ConsoleKey.D2:
                        var matchingMotoNum = functionsForSQL.MatchingMotoNumber();
                        sqlEdit.EditMotoData(matchingMotoNum.Item1, matchingMotoNum.Item2);
                        break;
                    case ConsoleKey.D3:
                        var matchingBikeID = functionsForSQL.CheckMatchingBikeID();
                        sqlEdit.EditBikeData(matchingBikeID.Item1, matchingBikeID.Item2);
                        break;
                    case ConsoleKey.D4:
                        var matchingClientPN = functionsForSQL.MathchingPersonalNumber();
                        sqlEdit.EditClientData(matchingClientPN.Item1, matchingClientPN.Item2);
                        break;
                    case ConsoleKey.D5:
                        var machingCarNumber2 = functionsForSQL.MatchingCarNumber();
                        sqlEdit.EditCarDocsData(machingCarNumber2.Item1, machingCarNumber2.Item2);
                        break;
                    case ConsoleKey.D6:
                        var matchingMotoNum2 = functionsForSQL.MatchingMotoNumber();
                        sqlEdit.EditMotoDocsData(matchingMotoNum2.Item1, matchingMotoNum2.Item2);
                        break;
                    case ConsoleKey.Backspace:
                        Console.Clear();
                        ShowMenu();
                        break;
                    case ConsoleKey.Escape:
                        Console.Clear();
                        Environment.Exit(0);
                        break;
                }
            }   
        }

        // Trynimo meniu valdymas
        public void DeleteMenuSelection()
        {
            bool needToRender = true;
            while (needToRender)
            {
                dataDeleteMenu.Render();
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                switch (pressedKey.Key)
                {
                    case ConsoleKey.D1:
                        var deleteCar = functionsForSQL.AvailabilityDeleteCar();
                        sqlDelete.DeleteCarRecord(deleteCar.Item1, deleteCar.Item2);
                        break;
                    case ConsoleKey.D2:
                        var deleteMoto = functionsForSQL.AvailabilityDeleteMoto();
                        sqlDelete.DeleteMotoRecord(deleteMoto.Item1, deleteMoto.Item2);
                        break;
                    case ConsoleKey.D3:
                        var deleteBike = functionsForSQL.AvailabilityDeleteBike();
                        sqlDelete.DeleteBikeRecord(deleteBike.Item1, deleteBike.Item2);
                        break;
                    case ConsoleKey.D4:
                        var deleteClient = functionsForSQL.AvailabilityDeleteClient();
                        sqlDelete.DeleteClientRecord(deleteClient.Item1, deleteClient.Item2);
                        break;
                    case ConsoleKey.Backspace:
                        Console.Clear();
                        ShowMenu();
                        break;
                    case ConsoleKey.Escape:
                        Console.Clear();
                        Environment.Exit(0);
                        break;
                }
            }
        }

        // Nuomavimo/grazinimo meniu valdymas
        public void RentMenuSelection()
        {
            bool needToRender = true;
            while (needToRender)
            {
                rentMenu.Render();
                ConsoleKeyInfo pressedChar = Console.ReadKey(true);
                switch (pressedChar.Key)
                {
                    case ConsoleKey.D1:
                        var carNumAndClientPN = functionsForSQL.MatchingCarNumberAndClientNumber();
                        sqlEdit.RentCar(carNumAndClientPN.Item1, carNumAndClientPN.Item2, carNumAndClientPN.Item3);
                        break;
                    case ConsoleKey.D2:
                        var motoNumAndClientPN = functionsForSQL.MatchingMotoNumberAndPersonalNumber();
                        sqlEdit.RentMoto(motoNumAndClientPN.Item1, motoNumAndClientPN.Item2, motoNumAndClientPN.Item3);
                        break;
                    case ConsoleKey.D3:
                        var bikeIDAndClientPN = functionsForSQL.MatchingBikeIDAndClientNumber();
                        sqlEdit.RentBike(bikeIDAndClientPN.Item1, bikeIDAndClientPN.Item2, bikeIDAndClientPN.Item3);
                        break;
                    case ConsoleKey.D4:
                        var carNumWithClient = functionsForSQL.MatchingCarNumberWithClient();
                        sqlEdit.CarGivedBack(carNumWithClient.Item1, carNumWithClient.Item2);
                        break;
                    case ConsoleKey.D5:
                        var motoNumWithClient = functionsForSQL.MatchingMotoNumberWithClient();
                        sqlEdit.MotoGivedBack(motoNumWithClient.Item1, motoNumWithClient.Item2);
                        break;
                    case ConsoleKey.D6:
                        var bikeIDWithClient = functionsForSQL.MatchingBikeIDWithClient();
                        sqlEdit.BikeGivedBack(bikeIDWithClient.Item1, bikeIDWithClient.Item2);
                        break;
                    case ConsoleKey.Backspace:
                        Console.Clear();
                        ShowMenu();
                        break;
                    case ConsoleKey.Escape:
                        Console.Clear();
                        Environment.Exit(0);
                        break;
                }
            }
        }

        // Duomenu isvedimo i ekrana meniu valdymas
        public void GetInfoSelectionMenu()
        {
            bool needToRender = true;            
            while (needToRender)
            {
                getInfoMenu.Render();
                ConsoleKeyInfo pressedChar = Console.ReadKey(true);
                switch(pressedChar.Key)
                {
                    case ConsoleKey.A:
                        functionsForCar.PrintAllData();
                        break;
                    case ConsoleKey.B:
                        functionsForMoto.PrintAllMotoData();
                        break;
                    case ConsoleKey.C:
                        functionsForBike.PrintAllData();
                        break;
                    case ConsoleKey.D:
                        functionsForClient.ClientData();
                        break;
                    case ConsoleKey.E:
                        functionsForCar.AvailableCarsToRentData();
                        break;
                    case ConsoleKey.F:
                        functionsForMoto.AvailableMotosToRentData();
                        break;
                    case ConsoleKey.G:
                        functionsForBike.AvailableBikesToRentData();
                        break;
                    case ConsoleKey.H:
                        functionsForCar.RentedCarsData();
                        break;
                    case ConsoleKey.I:
                        functionsForMoto.RentedMotosData();
                        break;
                    case ConsoleKey.J:
                        functionsForBike.RentedBikesData();
                        break;
                    case ConsoleKey.K:
                        functionsForCar.ValidDocsData();
                        break;
                    case ConsoleKey.L:
                        functionsForMoto.ValidDocsData();
                        break;
                    case ConsoleKey.Backspace:
                        Console.Clear();
                        ShowMenu();
                        break;
                    case ConsoleKey.Escape:
                        Console.Clear();
                        Environment.Exit(0);
                        break;
                }
            }
        }

        // Paieskos meniu valdymas
        public void SearchInfoSlectionMenu()
        {
            bool needToRender = true;
            while (needToRender)
            {
                searchInfoMenu.Render();
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                switch (pressedKey.Key)
                {
                    case ConsoleKey.D1:
                        var carWithClient = functionsForSQL.MatchingCarNumberWithClient();
                        functionsForCar.SearchByCar(carWithClient.Item1, carWithClient.Item2);
                        break;
                    case ConsoleKey.D2:
                        var motoWithClient = functionsForSQL.MatchingMotoNumberWithClient();
                        functionsForMoto.SearchByMoto(motoWithClient.Item1, motoWithClient.Item2);
                        break;
                    case ConsoleKey.D3:
                        var bikeWithClient = functionsForSQL.MatchingBikeIDWithClient();
                        functionsForBike.SearchByBikeID(bikeWithClient.Item1, bikeWithClient.Item2);
                        break;
                    case ConsoleKey.D4:
                        var clientPN = functionsForSQL.MathchingPersonalNumber();
                        functionsForClient.VehiclesRentedToClient(clientPN.Item1, clientPN.Item2);
                        break;
                    case ConsoleKey.D5:
                        var clientSurename = functionsForSQL.MathchingClientSurename();
                        functionsForClient.SearchBySurename(clientSurename.Item1, clientSurename.Item2);
                        break;
                    case ConsoleKey.Backspace:
                        Console.Clear();
                        ShowMenu();
                        break;
                    case ConsoleKey.Escape:
                        Console.Clear();
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
