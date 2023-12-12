
using Microsoft.EntityFrameworkCore;

namespace NeoApp.API.Models
{
    public partial class ControleConsultaContext : DbContext
    {
        public ControleConsultaContext()
        {
        }

        public ControleConsultaContext(DbContextOptions<ControleConsultaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Consulta> Consulta { get; set; }
        public virtual DbSet<Medico> Medico { get; set; }
        public virtual DbSet<Paciente> Paciente { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(local);Initial Catalog=ControleConsulta;Integrated Security=True;Encrypt=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Consulta>(entity =>
            {
                entity.HasOne(d => d.IdMedicoNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.IdMedico)
                    .HasConstraintName("FK_Consulta_Medico");

                entity.HasOne(d => d.IdPacienteNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.IdPaciente)
                    .HasConstraintName("FK_Consulta_Paciente");

                entity.Property(e => e.IdMedico).IsRequired();
                entity.Property(e => e.IdPaciente).IsRequired();
            });

            modelBuilder.Entity<Medico>(entity =>
            {
                entity.Property(e => e.NomeMedico).IsRequired();
            });

            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.Property(e => e.NomePaciente).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
