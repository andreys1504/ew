using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EclipseWorks.AdminTarefas.DataAccess.EfContext.Configurations;

public sealed class ProjetoConfigurations : IEntityTypeConfiguration<Projeto>
{
    public void Configure(EntityTypeBuilder<Projeto> builder)
    {
        builder.Ignore(e => e.Id2);

        builder.ToTable("Projeto");
        builder.HasKey(projeto => projeto.Id);

        builder.Property(projeto => projeto.Nome)
            .HasMaxLength(150)
            .IsRequired(false);

        builder.HasOne(projeto => projeto.Usuario)
            .WithMany(projeto => projeto.Projetos)
            .HasForeignKey(projeto => projeto.IdUsuario)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
