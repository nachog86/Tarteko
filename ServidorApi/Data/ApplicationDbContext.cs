using Microsoft.EntityFrameworkCore;

namespace ServidorApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        // Constructor que toma las opciones de configuración del DbContext
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        // Definición de los DbSet para cada entidad
        public DbSet<Inmueble> Inmuebles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Imagen> Imagenes { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<Transaccion> Transacciones { get; set; }
        public DbSet<UsuarioFavorito> UsuariosFavoritos { get; set; }
        public DbSet<UsuarioInmueble> UsuarioInmuebles { get; set; }

        // Configuración del modelo de base de datos
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de las claves primarias compuestas
            modelBuilder.Entity<UsuarioInmueble>().HasKey(ui => new { ui.UsuarioId, ui.InmuebleId });
            modelBuilder.Entity<UsuarioFavorito>().HasKey(uf => new { uf.UsuarioId, uf.InmuebleId });
        }
    }
}
