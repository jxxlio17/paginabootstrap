using Microsoft.EntityFrameworkCore;
using WebApplication2; // Asegúrate de que sea el namespace correcto de TuContexto.

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios al contenedor
builder.Services.AddRazorPages();

// Configurar el contexto de base de datos usando la cadena de conexión
builder.Services.AddDbContext<TuContexto>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configuración de la tubería de solicitud HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapRazorPages();
app.Run();
