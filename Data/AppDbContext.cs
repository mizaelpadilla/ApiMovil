using Microsoft.EntityFrameworkCore;
using ApiMovil.Models;

namespace ApiMovil.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(
            DbContextOptions<AppDbContext> options
        ) : base(options)
        {

        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Horario> Horarios { get; set; }
        public DbSet<Turno> Turnos { get; set; }
        public DbSet<Planificacion> Planificaciones { get; set; }
        public DbSet<Marcacion> Marcaciones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed de Empleado
            modelBuilder.Entity<Empleado>().HasData(
                new Empleado
                {
                    IdEmpleado = 1,
                    Nombres = "Misael",
                    Apellidos = "Admin",
                    DNI = "12345678",
                    Telefono = "999888777",
                    Correo = "misael@cibertec.com",
                    Estado = true
                }
            );

            // Seed de Usuario
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    IdUsuario = 1,
                    UsuarioNombre = "misael@cibertec.com",
                    Clave = "123456",
                    Rol = "Administrador",
                    IdEmpleado = 1,
                    Estado = true
                }
            );
        }
    }
}
