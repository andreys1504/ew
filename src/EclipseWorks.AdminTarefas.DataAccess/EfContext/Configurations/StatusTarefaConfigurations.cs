using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EclipseWorks.AdminTarefas.DataAccess.EfContext.Configurations;

public sealed class StatusTarefaConfigurations : IEntityTypeConfiguration<StatusTarefa>
{
    public void Configure(EntityTypeBuilder<StatusTarefa> builder)
    {
        builder.Ignore(e => e.Id2);

        builder.ToTable("StatusTarefa");
        builder.HasKey(status => status.Id);
        builder.Property(status => status.Id).ValueGeneratedNever();

        builder.Property(status => status.Nome)
            .HasMaxLength(150);
    }
}
