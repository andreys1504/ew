

### Desenvolvido Por

Andrey Mariano (andreys1504@gmail.com); 08/03/2024.


### Resumo Desenvolvimento

- Solution - Principais Camadas

Apresentação (Apis): .Api
Regras de negócio (Domain): .Application e .Domain
Infraestrutura: .DataAccess
Testes: .Application.Tests e .Tests

- Solution - Camadas auxiliares

Abstrações/Interfaces base, helpers (strings, dateTime, ...): .Base
Cross-Cutting - Injeção de Dependência: .Ioc

- Libs (Pacotes Nuget)

Acesso a dados: EntityFramework e Dapper
Testes Unitários: xUnit
Validação de dados: Flunt

- Banco de dados

SQL Server

- Configuração Ambiente

Docker

- Versionamento

Git


### Configurar Projeto

No diretório raiz, execute: ``` docker-compose up -d ```


### Acesso

http://localhost:5454/swagger/index.html

Id Usuário teste: '2E197F3F-A9D0-48F8-A893-7077677B32CA'

### Para P.O.

Em "Fase 1 - Regras de negócio", item 2, existem regras para "Remoção de Projetos", mais a funcionalidade não está listada nos itens a serem desenvolvidos.


### Futuras Melhorias

- Pipelines

Criar pipelines de build e deploy.


- Lib MediatR

Para AppServices (.Application), o uso da lib MediatR, tornaria mais fácil as chamadas as funcionalidades.


- 'EclipseWorks.AdminTarefas.Application'

Para Services, criar uma classe base e encapsular retornos (``` new AppResponse<> ```). Também encapsular chamadas a 'ITransaction'.


- 'EclipseWorks.AdminTarefas.Api'

Criar classe base para Controllers, estendendo ControllerBase, e criar returns padrão. Exemplo: Se Application retornar Success igual a false, o response do endpoint ser status 400.

