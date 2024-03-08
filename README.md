

### Desenvolvido Por

Andrey Mariano (andreys1504@gmail.com); 08/03/2024.


### Configurar Projeto

No diretório raiz, execute: ``` docker-compose up -d ```


### Acesso

http://localhost:5454/swagger/index.html


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


