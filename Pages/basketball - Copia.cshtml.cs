using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace WebApplication2.Pages
{
    public class BasketballCopiaModel : PageModel
    {
        private readonly TuContexto _contexto;

        public BasketballCopiaModel(TuContexto contexto)
        {
            _contexto = contexto;
        }

        [BindProperty]
        public FormularioViewModel Formulario { get; set; }

        public void OnGet()
        {
            Formulario = new FormularioViewModel();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var formulario = new Formulario
            {
                Nombre = Formulario.Nombre,
                Correo = Formulario.Correo,
                Asunto = Formulario.Asunto,
                Mensaje = Formulario.Mensaje
            };

            _contexto.Formulario.Add(formulario);
            await _contexto.SaveChangesAsync();

            Formulario.Enviado = true;

            return Page();
        }
    }

    public class FormularioViewModel
    {
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

        public bool Enviado { get; set; }
    }
}
