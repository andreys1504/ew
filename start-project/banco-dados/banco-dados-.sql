CREATE DATABASE AdminTarefas
GO

USE AdminTarefas
GO



IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [LogAlteracao] (
    [Id] uniqueidentifier NOT NULL,
    [IdEntidade] nvarchar(150) NULL,
    [Campo] nvarchar(150) NULL,
    [Valor] nvarchar(550) NULL,
    [DataHoraModificacao] datetime2 NOT NULL,
    [IdUsuario] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_LogAlteracao] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [PrioridadeTarefa] (
    [Id] int NOT NULL,
    [Nome] nvarchar(150) NULL,
    CONSTRAINT [PK_PrioridadeTarefa] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [StatusTarefa] (
    [Id] int NOT NULL,
    [Nome] nvarchar(150) NULL,
    CONSTRAINT [PK_StatusTarefa] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Usuario] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] nvarchar(150) NULL,
    [IdTipoUsuario] int NOT NULL,
    CONSTRAINT [PK_Usuario] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Projeto] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] nvarchar(150) NULL,
    [IdUsuario] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Projeto] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Projeto_Usuario_IdUsuario] FOREIGN KEY ([IdUsuario]) REFERENCES [Usuario] ([Id])
);
GO

CREATE TABLE [Tarefa] (
    [Id] uniqueidentifier NOT NULL,
    [IdProjeto] uniqueidentifier NOT NULL,
    [Titulo] nvarchar(150) NULL,
    [Descricao] nvarchar(500) NULL,
    [DataVencimento] DATE NOT NULL,
    [IdStatus] int NOT NULL,
    [IdPrioridadeTarefa] int NOT NULL,
    CONSTRAINT [PK_Tarefa] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Tarefa_PrioridadeTarefa_IdPrioridadeTarefa] FOREIGN KEY ([IdPrioridadeTarefa]) REFERENCES [PrioridadeTarefa] ([Id]),
    CONSTRAINT [FK_Tarefa_Projeto_IdProjeto] FOREIGN KEY ([IdProjeto]) REFERENCES [Projeto] ([Id]),
    CONSTRAINT [FK_Tarefa_StatusTarefa_IdStatus] FOREIGN KEY ([IdStatus]) REFERENCES [StatusTarefa] ([Id])
);
GO

CREATE INDEX [IX_Projeto_IdUsuario] ON [Projeto] ([IdUsuario]);
GO

CREATE INDEX [IX_Tarefa_IdPrioridadeTarefa] ON [Tarefa] ([IdPrioridadeTarefa]);
GO

CREATE INDEX [IX_Tarefa_IdProjeto] ON [Tarefa] ([IdProjeto]);
GO

CREATE INDEX [IX_Tarefa_IdStatus] ON [Tarefa] ([IdStatus]);
GO

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
                        (Id, Nome, IdTipoUsuario)
                    VALUES
                        ('2e197f3f-a9d0-48f8-a893-7077677b32ca', 'Andrey Mariano', 2)
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240308205039_Inicio', N'8.0.2');
GO

COMMIT;
GO

