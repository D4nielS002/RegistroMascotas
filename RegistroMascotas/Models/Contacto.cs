using System.ComponentModel.DataAnnotations;

namespace RegistroMascotas.Models
{
    public class Contacto
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Raza { get; set; }
        public double Peso { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
