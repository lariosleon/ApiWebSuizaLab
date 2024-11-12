using Microsoft.EntityFrameworkCore;
using Models;

namespace DB
{
    public class WebApiContext: DbContext
    {
        public WebApiContext(DbContextOptions<WebApiContext> options) : base(options) { }

        public DbSet<Especialidad>? Especialidads { get; set; }
        public DbSet<TipoDocumento>? TipoDocumentos { get; set; }
        public DbSet<Paciente>? Pacientes { get; set; }
        public DbSet<Citas>? Citass { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Especialidad>().ToTable("Especialidad");
            modelBuilder.Entity<TipoDocumento>().ToTable("TipoDocumento");
            modelBuilder.Entity<Paciente>().ToTable("Paciente");
            modelBuilder.Entity<Citas>().ToTable("Citas");
        }

    }



}
