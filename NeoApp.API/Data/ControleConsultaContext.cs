#nullable disable
using System;
using System.Collections.Generic;
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
            // Certifique-se de que a configuração do banco de dados está sendo fornecida ao contexto.
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

                // Adicione validações para garantir que as chaves estrangeiras não sejam nulas
                entity.Property(e => e.IdMedico).IsRequired();
                entity.Property(e => e.IdPaciente).IsRequired();

                // Adicione outras validações conforme necessário
            });

            modelBuilder.Entity<Medico>(entity =>
            {
                // Adicione validações para garantir que campos obrigatórios não sejam nulos
                entity.Property(e => e.NomeMedico).IsRequired();

                // Adicione outras validações conforme necessário
            });

            modelBuilder.Entity<Paciente>(entity =>
            {
                // Adicione validações para garantir que campos obrigatórios não sejam nulos
                entity.Property(e => e.NomePaciente).IsRequired();

                // Adicione outras validações conforme necessário
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
