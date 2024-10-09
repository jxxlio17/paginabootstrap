using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using System.Text;

namespace WebApplication2.Pages
{
    public class BasketballModel2 : PageModel
    {
        [BindProperty]
        public string Nombre { get; set; }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Asunto { get; set; }

        [BindProperty]
        public string Mensaje { get; set; }
        [TempData]
        public bool Enviado { get; set; } = false;  // Se inicializa como falso

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            // Ruta del archivo donde se guardarán los datos
            string filePath = "C:\\Users\\marce\\OneDrive - Universidad Autonoma de Nuevo León\\ESCUELA\\7\\Programacion distribuida\\paginabootstrap\\contact_form.txt";

            if (ModelState.IsValid)
            {
                // Crear el texto a guardar
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("----- Nuevo Mensaje -----");
                sb.AppendLine($"Nombre: {Nombre}");
                sb.AppendLine($"Correo Electrónico: {Email}");
                sb.AppendLine($"Asunto: {Asunto}");
                sb.AppendLine($"Mensaje: {Mensaje}");
                sb.AppendLine($"Fecha: {System.DateTime.Now}");
                sb.AppendLine("--------------------------\n");

                try
                {
                    // Escribir el texto en el archivo
                    using (StreamWriter writer = new StreamWriter(filePath, true))
                    {
                        writer.WriteLine(sb.ToString());
                    }

                    // Si se guarda correctamente, marcamos Enviado como true
                    Enviado = true;

                    // Redirigir para evitar reenvío del formulario
                    return RedirectToPage();
                }
                catch (IOException ex)
                {
                    // Manejar el error si ocurre un problema al escribir el archivo
                    ModelState.AddModelError(string.Empty, "Hubo un problema al guardar el mensaje. Inténtalo nuevamente.");
                }
            }

            return Page();  // Volver a mostrar la página si hay un error
        }
    }
}
