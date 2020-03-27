using Project.VehicleData;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Project.Repository
{
    class SQLSelect
    {
        const string connectionStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Project_Vehicles_Rent;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public SQLSelect()
        {

        }
        
        // Automobiliu paemimas is DB
        public List<Car> SelectCars()
        {
            List<Car> vehicles = new List<Car>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionStr))
            {
                sqlConnection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM cars",
                    sqlConnection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        vehicles.Add(new Car
                        {
                            VehNumber = reader.GetString(0),
                            Brand = reader.GetString(2),
                            Model = reader.GetString(3),
                            CarType = reader.GetString(4),
                            FuelType = reader.GetString(5),
                            Engine = reader.GetString(6),
                            Color = reader.GetString(7),
                            YearMade = reader.GetInt32(8),
                            RentPrice = reader.GetDouble(9),
                            RentStatus = reader.GetBoolean(10),
                            TechServiceExp = reader.GetDateTime(11).ToString("yyyy-MM-dd"),
                            InsuranceExp = reader.GetDateTime(12).ToString("yyyy-MM-dd")
                        });
                    }
                }
                sqlConnection.Close();
            }
            return vehicles;
        }

        // Isnuomotu automobiliu paemimas is DB
        public List<Car> SelectCarsWithClient()
        {
            List<Car> vehicles = new List<Car>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionStr))
            {
                sqlConnection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM cars WHERE clientNumber IS NOT NULL AND rentFrom IS NOT NULL",
                    sqlConnection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        vehicles.Add(new Car
                        {
                            VehNumber = reader.GetString(0),
                            ClientNumber = reader.GetInt64(1),
                            Brand = reader.GetString(2),
                            Model = reader.GetString(3),
                            CarType = reader.GetString(4),
                            FuelType = reader.GetString(5),
                            Engine = reader.GetString(6),
                            Color = reader.GetString(7),
                            YearMade = reader.GetInt32(8),
                            RentPrice = reader.GetDouble(9),
                            RentStatus = reader.GetBoolean(10),
                            TechServiceExp = reader.GetDateTime(11).ToString("yyyy-MM-dd"),
                            InsuranceExp = reader.GetDateTime(12).ToString("yyyy-MM-dd"),
                            RentFromDate = reader.GetDateTime(13).ToString("yyyy-MM-dd")
                        });
                    }
                }
                sqlConnection.Close();
            }
            return vehicles;
        }

        // Motociklu paemimas is DB
        public List<Motorcycle> SelectMotorcycles()
        {
            List<Motorcycle> motorcycles = new List<Motorcycle>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionStr))
            {
                sqlConnection.Open();
                using (SqlCommand command = new SqlCommand($"SELECT * FROM motorcycles", sqlConnection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        motorcycles.Add(new Motorcycle
                        {
                            VehNumber = reader.GetString(0),
                            Brand = reader.GetString(2),
                            Model = reader.GetString(3),
                            Engine = reader.GetString(4),
                            Color = reader.GetString(5),
                            YearMade = reader.GetInt32(6),
                            RentPrice = reader.GetDouble(7),
                            RentStatus = reader.GetBoolean(8),
                            TechServiceExp = reader.GetDateTime(9).ToString("yyyy-MM-dd"),
                            InsuranceExp = reader.GetDateTime(10).ToString("yyyy-MM-dd")
                        });
                    }
                }
                sqlConnection.Close();
            }
            return motorcycles;
        }

        // Isnuomotu motociklu paemimas is DB
        public List<Motorcycle> SelectMotorcyclesWithClient()
        {
            List<Motorcycle> motorcycles = new List<Motorcycle>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionStr))
            {
                sqlConnection.Open();
                using (SqlCommand command = new SqlCommand($"SELECT * FROM motorcycles WHERE clientNumber IS NOT NULL AND rentFrom IS NOT NULL",
                    sqlConnection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        motorcycles.Add(new Motorcycle
                        {
                            VehNumber = reader.GetString(0),
                            ClientNumber = reader.GetInt64(1),
                            Brand = reader.GetString(2),
                            Model = reader.GetString(3),
                            Engine = reader.GetString(4),
                            Color = reader.GetString(5),
                            YearMade = reader.GetInt32(6),
                            RentPrice = reader.GetDouble(7),
                            RentStatus = reader.GetBoolean(8),
                            TechServiceExp = reader.GetDateTime(9).ToString("yyyy-MM-dd"),
                            InsuranceExp = reader.GetDateTime(10).ToString("yyyy-MM-dd"),
                            RentFromDate = reader.GetDateTime(11).ToString("yyyy-MM-dd")
                        });
                    }
                }
                sqlConnection.Close();
            }
            return motorcycles;
        }

        // Dviraciu paemimas is DB
        public List<Bicycle> SelectBikes()
        {
            List<Bicycle> bikes = new List<Bicycle>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionStr))
            {
                sqlConnection.Open();
                using (SqlCommand command = new SqlCommand($"SELECT * from bicycles", sqlConnection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        bikes.Add(new Bicycle
                        {
                            BikeID = reader.GetInt32(0),
                            Brand = reader.GetString(2),
                            Model = reader.GetString(3),
                            Color = reader.GetString(4),
                            RentPrice = reader.GetDouble(5),
                            RentStatus = reader.GetBoolean(6)
                        });
                    }
                }
                sqlConnection.Close();
            }
            return bikes;
        }

        // Isnuomotu dviraciu paemimas is DB
        public List<Bicycle> SelectBikesWithClient()
        {
            List<Bicycle> bikes = new List<Bicycle>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionStr))
            {
                sqlConnection.Open();
                using (SqlCommand command = new SqlCommand($"SELECT * FROM bicycles WHERE clientNumber IS NOT NULL AND rentFrom IS NOT NULL",
                    sqlConnection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        bikes.Add(new Bicycle
                        {
                            BikeID = reader.GetInt32(0),
                            ClientNumber = reader.GetInt64(1),
                            Brand = reader.GetString(2),
                            Model = reader.GetString(3),
                            Color = reader.GetString(4),
                            RentPrice = reader.GetDouble(5),
                            RentStatus = reader.GetBoolean(6),
                            RentFromDate = reader.GetDateTime(7).ToString("yyyy-MM-dd")
                        });
                    }
                }
                sqlConnection.Close();
            }
            return bikes;
        }

        // Klientu paemimas is DB
        public List<Client> SelectClients()
        {
            List<Client> clients = new List<Client>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionStr))
            {
                sqlConnection.Open();
                using (SqlCommand command = new SqlCommand($"SELECT * from clients", sqlConnection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        clients.Add(new Client
                        {
                            PersonalNumber = reader.GetInt64(0),
                            Name = reader.GetString(1),
                            Surename = reader.GetString(2),
                            DateOfBirth = reader.GetDateTime(3).ToString("yyyy-MM-dd"),
                            Address = reader.GetString(4),
                            City = reader.GetString(5)
                        });
                    }
                }
                sqlConnection.Close();
            }
            return clients;
        }
    }
}
