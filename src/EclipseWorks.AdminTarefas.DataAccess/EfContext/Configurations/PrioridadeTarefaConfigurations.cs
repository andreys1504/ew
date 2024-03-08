using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EclipseWorks.AdminTarefas.DataAccess.EfContext.Configurations;

public sealed class PrioridadeTarefaConfigurations : IEntityTypeConfiguration<PrioridadeTarefa>
{
    public void Configure(EntityTypeBuilder<PrioridadeTarefa> builder)
    {
        builder.Ignore(e => e.Id2);

        builder.ToTable("PrioridadeTarefa");
        builder.HasKey(prioridade => prioridade.Id);
        builder.Property(prioridade => prioridade.Id).ValueGeneratedNever();

        builder.Property(prioridade => prioridade.Nome)
            .HasMaxLength(150);
    }
}
