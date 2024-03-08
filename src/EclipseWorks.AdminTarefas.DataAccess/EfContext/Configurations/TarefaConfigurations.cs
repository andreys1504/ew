using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EclipseWorks.AdminTarefas.DataAccess.EfContext.Configurations;

public sealed class TarefaConfigurations : IEntityTypeConfiguration<Tarefa>
{
    public void Configure(EntityTypeBuilder<Tarefa> builder)
    {
        builder.Ignore(e => e.Id2);

        builder.ToTable("Tarefa");
        builder.HasKey(tarefa => tarefa.Id);

        builder.Property(tarefa => tarefa.Titulo)
            .HasMaxLength(150);

        builder.Property(tarefa => tarefa.Descricao)
            .HasMaxLength(500)
            .IsRequired(false);

        builder.Property(tarefa => tarefa.DataVencimento)
            .HasColumnType("DATE");

        builder.HasOne(tarefa => tarefa.Projeto)
            .WithMany(tarefa => tarefa.Tarefas)
            .HasForeignKey(tarefa => tarefa.IdProjeto)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(tarefa => tarefa.StatusTarefa)
            .WithMany(tarefa => tarefa.Tarefas)
            .HasForeignKey(tarefa => tarefa.IdStatus)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(tarefa => tarefa.PrioridadeTarefa)
            .WithMany(tarefa => tarefa.Tarefas)
            .HasForeignKey(tarefa => tarefa.IdPrioridadeTarefa)
            .OnDelete(DeleteBehavior.NoAction);
    }
}