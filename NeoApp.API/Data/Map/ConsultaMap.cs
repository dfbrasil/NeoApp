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
            builder.Property(x => x.DataConsulta).IsRequired();
        }
    }
}
