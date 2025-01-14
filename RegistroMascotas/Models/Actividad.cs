using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace RegistroMascotas.Models
{
    public class Actividad
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string tipoActividad { get; set; }
        [Required]
        public string observacion { get; set; }
        [Required]
        public int ContactoId { get; set; }
        [ForeignKey("ContactoId")]//llamado al fk
        public Contacto Contacto { get; set; }

    }
}
