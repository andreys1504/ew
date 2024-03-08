using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EclipseWorks.AdminTarefas.DataAccess.EfContext.Configurations;

public sealed class UsuarioConfigurations : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.Ignore(e => e.Id2);

        builder.ToTable("Usuario");
        builder.HasKey(usuario => usuario.Id);

        builder.Property(usuario => usuario.Nome).HasMaxLength(150);
    }
}