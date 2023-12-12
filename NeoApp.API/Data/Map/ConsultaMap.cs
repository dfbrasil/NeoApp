using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NeoApp.API.Models;

namespace NeoApp.API.Data.Map
{
    public class ConsultaMap : IEntityTypeConfiguration<Consulta>
    {
        public void Configure(EntityTypeBuilder<Consulta> builder)
        {
            builder.HasKey(x => x.Id);

            // Validar a obrigatoriedade e o formato da data da consulta
            builder.Property(x => x.DataConsulta)
                .IsRequired()
                .HasColumnType("datetime"); // Ajuste o tipo conforme necessário

            // Relacionamento com a entidade Médico
            builder.HasOne(x => x.IdMedicoNavigation)
                .WithMany(m => m.Consulta)
                .HasForeignKey(x => x.IdMedico)
                .OnDelete(DeleteBehavior.Restrict);

            // Relacionamento com a entidade Paciente
            builder.HasOne(x => x.IdPacienteNavigation)
                .WithMany(p => p.Consulta)
                .HasForeignKey(x => x.IdPaciente)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
