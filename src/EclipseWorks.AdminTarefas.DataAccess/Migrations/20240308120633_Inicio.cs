using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EclipseWorks.AdminTarefas.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Inicio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LogAlteracao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdEntidade = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Campo = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Valor = table.Column<string>(type: "nvarchar(550)", maxLength: 550, nullable: true),
                    DataHoraModificacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogAlteracao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PrioridadeTarefa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrioridadeTarefa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusTarefa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusTarefa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projeto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projeto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projeto_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tarefa",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdProjeto = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DataVencimento = table.Column<DateOnly>(type: "DATE", nullable: false),
                    IdStatus = table.Column<int>(type: "int", nullable: false),
                    IdPrioridadeTarefa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarefa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tarefa_PrioridadeTarefa_IdPrioridadeTarefa",
                        column: x => x.IdPrioridadeTarefa,
                        principalTable: "PrioridadeTarefa",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tarefa_Projeto_IdProjeto",
                        column: x => x.IdProjeto,
                        principalTable: "Projeto",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tarefa_StatusTarefa_IdStatus",
                        column: x => x.IdStatus,
                        principalTable: "StatusTarefa",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projeto_IdUsuario",
                table: "Projeto",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefa_IdPrioridadeTarefa",
                table: "Tarefa",
                column: "IdPrioridadeTarefa");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefa_IdProjeto",
                table: "Tarefa",
                column: "IdProjeto");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefa_IdStatus",
                table: "Tarefa",
                column: "IdStatus");

            migrationBuilder.Sql(
                @"
                    INSERT INTO StatusTarefa
                        (Id, Nome)
                    VALUES
                        (1, 'Pendente'),
                        (2, 'Andamento'),
                        (3, 'Concluida');


                    INSERT INTO PrioridadeTarefa
                        (Id, Nome)
                    VALUES
                        (1, 'Baixa'),
                        (2, 'Média'),
                        (3, 'Alta');


                    INSERT INTO Usuario
                        (Id, Nome)
                    VALUES
                        ('2e197f3f-a9d0-48f8-a893-7077677b32ca', 'Andrey Mariano')
                ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"
                    DELETE LogAlteracao;
                    DELETE Tarefa;
                    DELETE Projeto;
                    DELETE Usuario;
                    DELETE PrioridadeTarefa;
                    DELETE StatusTarefa;
                ");

            migrationBuilder.DropTable(
                name: "LogAlteracao");

            migrationBuilder.DropTable(
                name: "Tarefa");

            migrationBuilder.DropTable(
                name: "PrioridadeTarefa");

            migrationBuilder.DropTable(
                name: "Projeto");

            migrationBuilder.DropTable(
                name: "StatusTarefa");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
