using LoginMVCClase.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LoginMVCClase.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult ForMethod(string username, string password, string name, string fechanacimiento, string email)
        {
            UsuarioModel usuario;
            List<UsuarioModel> listUsuario = new List<UsuarioModel>();

            if (password == "password")
            {
                ViewBag.Error = "ERROR";
            }
            else
            {

            
                for (int i = 0; i <= 5; i++)

                {
                    usuario = new UsuarioModel();
                    usuario.email = "gabrieldisante@hotmail.com";
                    usuario.username = "gdisante";
                    usuario.password = "password";
                    usuario.fechanacimiento = DateTime.Now;
                    usuario.name = "Gbariel Di Sante";
                    usuario.id = i;


                    listUsuario.Add(usuario);

                }
            ViewBag.ListaUsuarios = listUsuario;
            }

            return View("Index");

        }
    }
}
