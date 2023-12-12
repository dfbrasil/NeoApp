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

            builder.Property(x => x.DataConsulta)
                .IsRequired()
                .HasColumnType("datetime");

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
