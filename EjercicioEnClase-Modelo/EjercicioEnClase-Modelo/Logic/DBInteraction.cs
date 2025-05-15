using Microsoft.Data.SqlClient;
using Microsoft.SqlServer;
using System.Data;

namespace EjercicioEnClase_Modelo.Logic
{
    public class DBInteraction
    {
        public string connectionString = "Server=localhost\\SQLEXPRESS;Database=master;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True";
        public DBInteraction() { }  
        public DBInteraction(int id) { }    

        public bool ModificarEstudianteCarreraEnDb(int id, string newValue )
        {
            string query = "UPDATE Estudiante SET Carrera = @newValue WHERE Id = @id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Parámetros para prevenir SQL Injection
                    command.Parameters.Add("@newValue", SqlDbType.NVarChar).Value = newValue;
                    command.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                       
                    }
                    catch (Exception ex)
                    {
                       
                    }
                }

                return true;
            }
        }

    }
}
