using Project.Functions;
using Project.VehicleData;
using System.Data.SqlClient;

namespace Project.Repository
{
    class SQLInsert
    {
        const string connectionStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Project_Vehicles_Rent;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private CarManagement functionsForCar = new CarManagement();
        private MotoManagement functionsForMoto = new MotoManagement();
        private BikeManagement functionsForBike = new BikeManagement();
        private ClientManagement functionsForClient = new ClientManagement();
        public SQLInsert()
        {

        }

        // Automobilio duomenu ivedimas
        public void InsertCar(bool vehNumNotExist, string vehNumber)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionStr))
            {
                if (vehNumNotExist)
                {
                    Car car = functionsForCar.MakeCarRecord();
                    sqlConnection.Open();
                    using SqlCommand command = new SqlCommand($"INSERT INTO cars (car_number, brand, model, carType, fuelType, engine," +
                        $"color, carYear, rentPrice, techServiceExp, insuranceExp) VALUES (@vehNumber, @brand, @model, " +
                        $"@carType, @fuelType, @engine, @color, @yearMade, @rentPrice, @techServiceExp, @insuranceExp)", sqlConnection);
                    command.Parameters.AddWithValue("@vehNumber", vehNumber);
                    command.Parameters.AddWithValue("@brand", car.Brand);
                    command.Parameters.AddWithValue("@model", car.Model);
                    command.Parameters.AddWithValue("@carType", car.CarType);
                    command.Parameters.AddWithValue("@fuelType", car.FuelType);
                    command.Parameters.AddWithValue("@engine", car.Engine);
                    command.Parameters.AddWithValue("@color", car.Color);
                    command.Parameters.AddWithValue("@yearMade", car.YearMade);
                    command.Parameters.AddWithValue("@rentPrice", car.RentPrice);
                    command.Parameters.AddWithValue("@techServiceExp", car.TechServiceExp);
                    command.Parameters.AddWithValue("@insuranceExp", car.InsuranceExp);
                    command.ExecuteNonQuery();
                    sqlConnection.Close();
                }
            }
        }

        // Motociklo duomenu ivedimas
        public void InsertMoto(bool vehNumNotExist, string vehNumber)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionStr))
            {
                if (vehNumNotExist)
                {
                    Motorcycle moto = functionsForMoto.MakeMotoRecord();
                    sqlConnection.Open();
                    using SqlCommand command = new SqlCommand($"INSERT INTO motorcycles (motoNumber, brand, model, engine, " +
                        $"color, year, rentPrice, techServiceExp, insuranceExp) VALUES (@vehNumber, @brand, @model, " +
                        $"@engine, @color, @yearMade, @rentPrice, @techServiceExp, @insuranceExp)", sqlConnection);
                    command.Parameters.AddWithValue("@vehNumber", vehNumber);
                    command.Parameters.AddWithValue("@brand", moto.Brand);
                    command.Parameters.AddWithValue("@model", moto.Model);
                    command.Parameters.AddWithValue("@engine", moto.Engine);
                    command.Parameters.AddWithValue("@color", moto.Color);
                    command.Parameters.AddWithValue("@yearMade", moto.YearMade);
                    command.Parameters.AddWithValue("@rentPrice", moto.RentPrice);
                    command.Parameters.AddWithValue("@techServiceExp", moto.TechServiceExp);
                    command.Parameters.AddWithValue("@insuranceExp", moto.InsuranceExp);
                    command.ExecuteNonQuery();
                    sqlConnection.Close();
                }
            }
        }

        // Dviracio duomenu ivedimas
        public void InsertBike()
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionStr))
            {
                Bicycle bike = functionsForBike.MakeBikeRecord();
                sqlConnection.Open();
                using SqlCommand command = new SqlCommand($"INSERT INTO bicycles (brand, model, color, rentPrice)" +
                    $"VALUES (@brand, @model, @color, @rentPrice)", sqlConnection);
                command.Parameters.AddWithValue("@brand", bike.Brand);
                command.Parameters.AddWithValue("@model", bike.Model);
                command.Parameters.AddWithValue("@color", bike.Color);
                command.Parameters.AddWithValue("@rentPrice", bike.RentPrice);
                command.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }

        // Kliento duomenu ivedimas
        public void InsertClient(bool personalNumNotExist, long personalNumber)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionStr))
            {
                if (personalNumNotExist)
                {
                    Client client = functionsForClient.AddClient();
                    sqlConnection.Open();
                    using SqlCommand command = new SqlCommand($"INSERT INTO clients (personalNumber, name, surename, dateOfBirth, address, city)" +
                        $"VALUES (@personalNumber, @name, @surename, @dateOfBirth, @address, @city)", sqlConnection);
                    command.Parameters.AddWithValue("@personalNumber", personalNumber);
                    command.Parameters.AddWithValue("@name", client.Name);
                    command.Parameters.AddWithValue("@surename", client.Surename);
                    command.Parameters.AddWithValue("@dateOfBirth", client.DateOfBirth);
                    command.Parameters.AddWithValue("@address", client.Address);
                    command.Parameters.AddWithValue("@city", client.City);
                    command.ExecuteNonQuery();
                    sqlConnection.Close();
                }
            }
        }      
    }
}
