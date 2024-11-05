using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace WebApplication2.Pages
{
    public class GestionFormularioModel : PageModel
    {
        private readonly TuContexto _contexto;

        public GestionFormularioModel(TuContexto contexto)
        {
            _contexto = contexto;
        }

        [BindProperty]
        public FormularioViewModel Formulario { get; set; }
        public List<Formulario> Formularios { get; set; }

        public void OnGet()
        {
            Formularios = _contexto.Formulario.ToList(); // Cargar todos los formularios para la sección de consulta
        }

        public async Task<IActionResult> OnPostInsertarAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var nuevoFormulario = new Formulario
            {
                Nombre = Formulario.Nombre,
                Correo = Formulario.Correo,
                Asunto = Formulario.Asunto,
                Mensaje = Formulario.Mensaje
            };

            _contexto.Formulario.Add(nuevoFormulario);
            await _contexto.SaveChangesAsync();

            return RedirectToPage(); // Redirigir para refrescar la página
        }

        public async Task<IActionResult> OnPostActualizarAsync()
        {
            var formularioExistente = await _contexto.Formulario.FindAsync(Formulario.Id);

            if (formularioExistente == null)
            {
                return NotFound();
            }

            formularioExistente.Nombre = Formulario.Nombre;
            formularioExistente.Correo = Formulario.Correo;
            formularioExistente.Asunto = Formulario.Asunto;
            formularioExistente.Mensaje = Formulario.Mensaje;

            await _contexto.SaveChangesAsync();

            return RedirectToPage(); // Redirigir para refrescar la página
        }
    }

    public class FormularioViewModel
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
