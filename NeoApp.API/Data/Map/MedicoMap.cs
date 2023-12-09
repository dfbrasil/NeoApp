using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using NeoApp.API.Models;

namespace NeoApp.API.Data.Map
{
    public class MedicoMap : IEntityTypeConfiguration<Medico>
    {
        public void Configure(EntityTypeBuilder<Medico> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.NomeMedico).IsRequired();
        }
    }
}
