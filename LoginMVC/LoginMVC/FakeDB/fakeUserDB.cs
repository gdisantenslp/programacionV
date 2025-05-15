using LoginMVC.Models;

namespace LoginMVC.FakeDB
{
    public class fakeUserDB
    {

        public static List<UsuarioModel> Users = new List<UsuarioModel>
    {
        new UsuarioModel { Id = 1, Username = "admin", Password = "1234" },
        new UsuarioModel { Id = 2, Username = "gabriel", Password = "abcd" }
    };

    }
}
