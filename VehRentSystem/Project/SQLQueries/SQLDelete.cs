using Project.Functions;
using System.Data.SqlClient;

namespace Project.SQLQueries
{
    class SQLDelete
    {
        const string connectionStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Project_Vehicles_Rent;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public SQLDelete()
        {

        }

        // Automobilio iraso trynimas
        public void DeleteCarRecord(bool carNumExist, string vehNumber)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionStr))
            {
                if (carNumExist)
                {
                    sqlConnection.Open();
                    using SqlCommand command = new SqlCommand($"DELETE FROM cars WHERE car_number = @vehNumber",
                        sqlConnection);
                    command.Parameters.AddWithValue("@vehNumber", vehNumber);
                    command.ExecuteNonQuery();
                    sqlConnection.Close();
                }
            }
        }

        // Motociklo iraso trynimas
        public void DeleteMotoRecord(bool motoNumExist, string vehNumber)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionStr))
            {
                if (motoNumExist)
                {
                    sqlConnection.Open();
                    using SqlCommand command = new SqlCommand($"DELETE FROM motorcycles WHERE motoNumber = @vehNumber",
                        sqlConnection);
                    command.Parameters.AddWithValue("@vehNumber", vehNumber);
                    command.ExecuteNonQuery();
                    sqlConnection.Close();
                }
            }
        }

        // Dviracio iraso trynimas
        public void DeleteBikeRecord(bool bikeIDExist, int bikeID)
        {
            if (bikeIDExist)
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionStr))
                {
                    sqlConnection.Open();
                    using SqlCommand command = new SqlCommand($"DELETE FROM bicycles WHERE bike_ID = @bikeID",
                        sqlConnection);
                    command.Parameters.AddWithValue("@bikeID", bikeID);
                    command.ExecuteNonQuery();
                    sqlConnection.Close();
                }
            }
        }

        // Kliento iraso trynimas
        public void DeleteClientRecord(bool personalNumExist, long personalNumber)
        {
            if (personalNumExist)
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionStr))
                {
                    sqlConnection.Open();
                    using SqlCommand command = new SqlCommand($"DELETE FROM clients WHERE personalNumber = @personalNumber",
                        sqlConnection);
                    command.Parameters.AddWithValue("@personalNumber", personalNumber);
                    command.ExecuteNonQuery();
                    sqlConnection.Close();
                }
            }
        }
    }
}