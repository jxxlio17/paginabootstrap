using Microsoft.EntityFrameworkCore;

namespace WebApplication2
{
    public class TuContexto : DbContext
    {
        public TuContexto(DbContextOptions<TuContexto> options) : base(options)
        {
        }

        public DbSet<Formulario> Formulario { get; set; }
    }
}
