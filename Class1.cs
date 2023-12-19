using System;
using System.Data.SqlClient;

class Program
{
	static void Main()
	{
		string connectionString = "Kafedra";
		using (SqlConnection conection = new SqlConnection(connectionString))
		{
			conection.Open();

			string sqlQuery = "SELECT * FROM Kafedra WHERE position = @position AND degree = @degree";

			using (SqlCommand command = new SqlCommand(sqlQuery, conection))
			{
				Console.WriteLine("Введіть посаду викладача");
				string position = Console.ReadLine();
				command.Parameters.AddWithValue("@position, position");

				Console.WriteLine("Введіть ступінь викладача");
				string degree = Console.ReadLine();
				command.Parameters.AddWithValue("@degree", degree);

				SqlDataReader reader = command.ExecuteReader();

				while (reader.Read())
				{
					Console.WriteLine($"{reader["surname"]} - {reader["position"]} - - {reader["degree"]}");
				}
				reader.Close();
			}
		}
	}
}
