using Project.Functions;
using System.Data.SqlClient;

namespace Project.SQLQueries
{
    class SQLEdit
    {
        const string connectionStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Project_Vehicles_Rent;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private CarManagement functionsForCar = new CarManagement();
        private MotoManagement functionsForMoto = new MotoManagement();
        private BikeManagement functionsForBike = new BikeManagement();
        private ClientManagement functionsForClient = new ClientManagement();
        private VehicleMenagement functionsForVehicle = new VehicleMenagement();
        public SQLEdit()
        {

        }

        // Automobilio tam tikru duomenu redagavimas
        public void EditCarData(bool carNumExist, string vehNumber)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionStr))
            {
                if (carNumExist)
                {
                    var carData = functionsForCar.EditCarData();
                    sqlConnection.Open();
                    using SqlCommand command = new SqlCommand($"UPDATE cars SET color = @color, rentPrice = @rentPrice " +
                        $"WHERE car_number = @vehNumber", sqlConnection);
                    command.Parameters.AddWithValue("@color", carData.Item1);
                    command.Parameters.AddWithValue("@rentPrice", carData.Item2);
                    command.Parameters.AddWithValue("@vehNumber", vehNumber);
                    command.ExecuteNonQuery();
                    sqlConnection.Close();
                }
            }
        }

        // Automobilio TA ir draudimo galiojimo datu redagavimas
        public void EditCarDocsData(bool carNumExist, string vehNumber)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionStr))
            {
                if (carNumExist)
                {
                    var carDocsData = functionsForCar.EditCarDocsData(vehNumber);
                    sqlConnection.Open();
                    using SqlCommand command = new SqlCommand($"UPDATE cars SET techServiceExp = @techServiceExp, " +
                        $"insuranceExp = @insuranceExp WHERE car_number = @vehNumber",
                        sqlConnection);
                    command.Parameters.AddWithValue("@techServiceExp", carDocsData.Item1);
                    command.Parameters.AddWithValue("@insuranceExp", carDocsData.Item2);
                    command.Parameters.AddWithValue("@vehNumber", vehNumber);
                    command.ExecuteNonQuery();
                    sqlConnection.Close();
                }
            }
        }

        // Motociklo tam tikru duomenu redagavimas
        public void EditMotoData(bool motoNumExist, string vehNumber)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionStr))
            {
                if (motoNumExist)
                {
                    var editMotoData = functionsForMoto.EditData();
                    sqlConnection.Open();
                    using SqlCommand command = new SqlCommand($"UPDATE motorcycles SET color = @color, rentPrice = @rentPrice" +
                        $" WHERE motoNumber = @vehNumber",
                        sqlConnection);
                    command.Parameters.AddWithValue("@color", editMotoData.Item1);
                    command.Parameters.AddWithValue("@rentPrice", editMotoData.Item2);
                    command.Parameters.AddWithValue("@vehNumber", vehNumber);
                    command.ExecuteNonQuery();
                    sqlConnection.Close();
                }
            }
        }

        // Motociklo TA ir draudimo galiojimo laiko redagavimas
        public void EditMotoDocsData(bool motoNumExist, string vehNumber)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionStr))
            {
                if (motoNumExist)
                {
                    var editMotoDocs = functionsForMoto.EditMotoDocsData(vehNumber);
                    sqlConnection.Open();
                    using SqlCommand command = new SqlCommand($"UPDATE motorcycles SET techServiceExp = @techServiceExp, " +
                        $"insuranceExp = @insuranceExp WHERE motoNumber = @vehNumber",
                        sqlConnection);
                    command.Parameters.AddWithValue("@techServiceExp", editMotoDocs.Item1);
                    command.Parameters.AddWithValue("@insuranceExp",editMotoDocs.Item2);
                    command.Parameters.AddWithValue("@vehNumber", vehNumber);
                    command.ExecuteNonQuery();
                    sqlConnection.Close();
                }
            }
        }

        // Dviracio nuomos kainos redagavimas
        public void EditBikeData(bool bikeIDExist, int bikeID)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionStr))
            {
                if (bikeIDExist)
                {
                    double? editData = functionsForBike.EditData();
                    sqlConnection.Open();
                    using SqlCommand command = new SqlCommand($"UPDATE bicycles SET rentPrice = @rentPrice WHERE bike_ID = @bikeID",
                        sqlConnection);
                    command.Parameters.AddWithValue("@rentPrice", editData);
                    command.Parameters.AddWithValue("@bikeID", bikeID);
                    command.ExecuteNonQuery();
                    sqlConnection.Close();
                }
            }
        }

        // Kliento duomenu redagavimas
        public void EditClientData(bool personalNumExist, long personalNumber)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionStr))
            {
                if (personalNumExist)
                {
                    var clientData = functionsForClient.EditData();
                    sqlConnection.Open();
                    using SqlCommand command = new SqlCommand($"UPDATE clients SET address = @address, city = @city" +
                        $" WHERE personalNumber = @personalNumber",
                        sqlConnection);
                    command.Parameters.AddWithValue("@address", clientData.Item1);
                    command.Parameters.AddWithValue("@city", clientData.Item2);
                    command.Parameters.AddWithValue("@personalNumber", personalNumber);
                    command.ExecuteNonQuery();
                    sqlConnection.Close();
                }
            }
        }

        // Duomenu atnaujinimas isnuomojant automobili
        public void RentCar(bool carAndPersonalNumsExist, string vehNumber, long clientNumber)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionStr))
            {
                if (carAndPersonalNumsExist)
                {
                    var rentData = functionsForVehicle.VehRenting();
                    sqlConnection.Open();
                    using SqlCommand command = new SqlCommand($"UPDATE cars SET clientNumber = @clientNumber, rentStatus = @rentStatus, " +
                        $"rentFrom = @rentFrom WHERE car_number = @vehNumber", sqlConnection);
                    command.Parameters.AddWithValue("@clientNumber", clientNumber);
                    command.Parameters.AddWithValue("@rentStatus", rentData.Item2);
                    command.Parameters.AddWithValue("@vehNumber", vehNumber);
                    command.Parameters.AddWithValue("@rentFrom", rentData.Item1);
                    command.ExecuteNonQuery();
                    sqlConnection.Close();
                }
            }
        }

        // Duomenu atnaujinimas isnuomojant motocikla
        public void RentMoto(bool motoAndPersonalNumsExist, string vehNumber, long clientNumber)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionStr))
            {
                if (motoAndPersonalNumsExist)
                {
                    var rentData = functionsForVehicle.VehRenting();
                    sqlConnection.Open();
                    using SqlCommand command = new SqlCommand($"UPDATE motorcycles SET clientNumber = @clientNumber, " +
                        $"rentStatus = @rentStatus, rentFrom = @rentFrom WHERE motoNumber = @vehNumber", sqlConnection);
                    command.Parameters.AddWithValue("@clientNumber", clientNumber);
                    command.Parameters.AddWithValue("@rentStatus", rentData.Item2);
                    command.Parameters.AddWithValue("@vehNumber", vehNumber);
                    command.Parameters.AddWithValue("@rentFrom", rentData.Item1);
                    command.ExecuteNonQuery();
                    sqlConnection.Close();
                }
            }
        }

        // Duomenu atnaujinimas isnuomojant dvirati
        public void RentBike(bool bikeIDAndPersonalNumExist, int bikeID, long clientNumber)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionStr))
            {
                if (bikeIDAndPersonalNumExist)
                {
                    var rentData = functionsForVehicle.VehRenting();                    
                    sqlConnection.Open();
                    using SqlCommand command = new SqlCommand($"UPDATE bicycles SET clientNumber = @clientNumber, " +
                        $"rentStatus = @rentStatus, rentFrom = @rentFrom WHERE bike_ID = @bikeID", sqlConnection);
                    command.Parameters.AddWithValue("@clientNumber", clientNumber);
                    command.Parameters.AddWithValue("@rentStatus", rentData.Item2);
                    command.Parameters.AddWithValue("@bikeID", bikeID);
                    command.Parameters.AddWithValue("@rentFrom", rentData.Item1);
                    command.ExecuteNonQuery();
                    sqlConnection.Close();
                }
            }
        }

        // Duomenu atnaujinimas grazinant automobili
        public void CarGivedBack(bool carNumExist, string vehNumber)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionStr))
            {
                if (carNumExist)
                {
                    bool rentStatus = functionsForCar.CarGivedBack(vehNumber);
                    sqlConnection.Open();
                    using SqlCommand command = new SqlCommand($"UPDATE cars SET clientNumber = NULL, rentStatus = @rentStatus, " +
                        $"rentFrom = NULL WHERE car_number = @vehNumber", sqlConnection);
                    command.Parameters.AddWithValue("@rentStatus", rentStatus);
                    command.Parameters.AddWithValue("@vehNumber", vehNumber);
                    command.ExecuteNonQuery();
                    sqlConnection.Close();
                }
            }
        }

        // Duomenu atnaujinimas grazinant motocikla
        public void MotoGivedBack(bool motoNumExist, string vehNumber)
        {
            if (motoNumExist)
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionStr))
                {
                    bool rentStatus = functionsForMoto.MotoGivedBack(vehNumber);
                    sqlConnection.Open();
                    using SqlCommand command = new SqlCommand($"UPDATE motorcycles SET clientNumber = NULL, rentStatus = @rentStatus, " +
                        $"rentFrom = NULL WHERE motoNumber = @vehNumber", sqlConnection);
                    command.Parameters.AddWithValue("@rentStatus", rentStatus);
                    command.Parameters.AddWithValue("@vehNumber", vehNumber);
                    command.ExecuteNonQuery();
                    sqlConnection.Close();
                }
            }
        }

        // Duomenu atnaujinimas grazinant dvirati
        public void BikeGivedBack(bool bikeIDExist, int bikeID)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionStr))
            {
                if (bikeIDExist)
                {
                    var rentStatus = functionsForBike.BikeGivedBack(bikeID);
                    sqlConnection.Open();
                    using SqlCommand command = new SqlCommand($"UPDATE bicycles SET clientNumber = NULL, rentStatus = @rentStatus, " +
                        $"rentFrom = NULL WHERE bike_ID = @bikeID", sqlConnection);
                    command.Parameters.AddWithValue("@rentStatus", rentStatus);
                    command.Parameters.AddWithValue("@bikeID", bikeID);
                    command.ExecuteNonQuery();
                    sqlConnection.Close();
                }
            }
        }
    }
}
