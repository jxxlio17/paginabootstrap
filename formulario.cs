using System.ComponentModel.DataAnnotations;

namespace WebApplication2
{
    public class Formulario
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Correo { get; set; }

        [Required]
        [StringLength(50)]
        public string Asunto { get; set; }

        [Required]
        [StringLength(50)]
        public string Mensaje { get; set; }
    }

}
