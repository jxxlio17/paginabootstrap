using Microsoft.EntityFrameworkCore;
using WebApplication2; // Aseg�rate de que sea el namespace correcto de TuContexto.

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios al contenedor
builder.Services.AddRazorPages();

// Configurar el contexto de base de datos usando la cadena de conexi�n
builder.Services.AddDbContext<TuContexto>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configuraci�n de la tuber�a de solicitud HTTP
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
