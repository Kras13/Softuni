using Microsoft.Data.SqlClient;
using System;

namespace ADO_NET_FULL_EXC
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=DESKTOP-6SUDEUL\\SQLEXPRESS;Database=MinionsDB;Trusted_Connection=True;";

            SqlConnection sqlConnetion = new SqlConnection(connectionString);
            sqlConnetion.Open();

            using (sqlConnetion)
            {
                MinionNames(sqlConnetion, 1);
            }
        }

        #region Problem1
        private static void VillainNames(SqlConnection sqlConnection)
        {
            string queryString = @"SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount  
                                FROM Villains AS v 
                                JOIN MinionsVillains AS mv ON v.Id = mv.VillainId 
                            GROUP BY v.Id, v.Name 
                                HAVING COUNT(mv.VillainId) > 3 
                            ORDER BY COUNT(mv.VillainId)";

            SqlCommand command = new SqlCommand(queryString, sqlConnection);

            SqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                string name = (string)dataReader.GetValue(dataReader.GetOrdinal("Name"));
                string minionsCount = dataReader.GetValue(dataReader.GetOrdinal("MinionsCount")).ToString();

                Console.WriteLine($"{name} - {minionsCount}");
            }
        }
        #endregion

        #region Problem2

        private static void MinionNames(SqlConnection sqlConnection, int villianId)
        {
            string selectedVillainQuery = "SELECT Name FROM Villains WHERE Id = @Id";

            SqlCommand getVillianNameById = new SqlCommand(selectedVillainQuery, sqlConnection);

            getVillianNameById.Parameters.AddWithValue("@Id", villianId);

            object villianName = getVillianNameById.ExecuteScalar();

            if (villianName == null)
            {
                Console.WriteLine($"No villain with ID {villianId} exists in the database.");
            }
            else
            {
                string villianMinionsQuery = @"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) as RowNum,
                                                    m.Name, 
                                                    m.Age
                                                FROM MinionsVillains AS mv
                                                JOIN Minions As m ON mv.MinionId = m.Id
                                               WHERE mv.VillainId = @Id
                                            ORDER BY m.Name";

                SqlCommand getVillianMinions = new SqlCommand(villianMinionsQuery, sqlConnection);
                getVillianMinions.Parameters.AddWithValue("@Id", villianId);

                SqlDataReader dataReader = getVillianMinions.ExecuteReader();

                Console.WriteLine($"Vllian name: {villianName}");

                using (dataReader)
                {
                    if (!dataReader.HasRows)
                    {
                        Console.WriteLine("(no minions)");
                    }
                    else
                    {
                        while (dataReader.Read())
                        {
                            string rowNum = dataReader.GetValue(dataReader.GetOrdinal("RowNum")).ToString();
                            string minionName = (string)dataReader.GetValue(dataReader.GetOrdinal("Name"));
                            string minionAge = dataReader.GetValue(dataReader.GetOrdinal("Age")).ToString();
                            Console.WriteLine($"{rowNum}. {minionName} {minionAge}");
                        }
                    }
                }

                
            }
        }

        #endregion


    }
}
