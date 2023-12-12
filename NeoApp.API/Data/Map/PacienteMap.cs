using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using NeoApp.API.Models;

namespace NeoApp.API.Data.Map
{
    public class PacienteMap : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.NomePaciente)
                .IsRequired()
                .HasMaxLength(50);

            //Relacionamento com a tabela Consulta
            builder.HasMany(x => x.Consulta)
                .WithOne(c => c.IdPacienteNavigation)
                .HasForeignKey(c => c.IdPaciente)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
