using LoginMVCClase.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;


namespace LoginMVCClase.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        string connectionString = @"Server=localhost\SQLEXPRESS;Database=ProgrammingV;Trusted_Connection=True;TrustServerCertificate=True;";

        public ActionResult Lista()
        {

            List<UsuarioModel> usuarios = new List<UsuarioModel>();

            using (SqlConnection connection = new SqlConnection(connectionString)) {

                string query = "SELECT id, username, name, fechanacimiento, email, password from Usuarios";
            
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read()) {

                    usuarios.Add(new UsuarioModel
                    {
                        id = reader.GetInt32(0),
                        username = reader.GetString(1),
                        name = reader.GetString(2),
                        fechanacimiento = Convert.ToDateTime(reader.GetString(3)),
                        email = reader.GetString(4),
                        password    = reader.GetString(5)



                    });
                
                }
                return View(usuarios);

            }
                



            return View();
        }



        public ActionResult ForMethod(string username, string password, string name, string fechanacimiento, string email)
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"INSERT INTO Usuarios (username, name, fechanacimiento, email, password) " +
                        " VALUES (@username, @name, @fechanacimiento,@email,@password)  ";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@fechanacimiento", fechanacimiento);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@password", password);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {

                        ViewBag.Mensaje = "Usuario Creado exitosamente!";
                    }
                    else
                    {
                        ViewBag.Mensaje = "Error - Usuario no creado";
                    }


                }

            }
            catch (Exception ex) { 
            
                ViewBag.Error  = "Error al insertar el usuario " + username + ": " + ex.Message;

            }


            return View("Index");

        }
    }
}
