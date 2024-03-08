using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EclipseWorks.AdminTarefas.DataAccess.EfContext.Configurations;

public sealed class LogAlteracaoConfigurations : IEntityTypeConfiguration<LogAlteracao>
{
    public void Configure(EntityTypeBuilder<LogAlteracao> builder)
    {
        builder.Ignore(e => e.Id2);

        builder.ToTable("LogAlteracao");
        builder.HasKey(log => log.Id);

        builder.Property(log => log.IdEntidade)
            .HasMaxLength(150);

        builder.Property(log => log.Campo)
            .HasMaxLength(150);

        builder.Property(log => log.Valor)
            .HasMaxLength(550);
    }
}
