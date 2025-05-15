namespace EjercicioEnClase_Modelo.Models
{
    public class Estudiante
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string carrera { get; set; }
        public DateTime? FechaNacimiento { get; set; }

        public string apellido { get; set; }    
    }
}
