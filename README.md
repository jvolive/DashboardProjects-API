# Dashboard React com ASP.NET

Este é um projeto de exemplo de um dashboard desenvolvido usando o framework React com Ant Design para o frontend e o framework ASP.NET para o backend.
Aqui eu apresento a API desenvolvida para esse projeto

## Ferramentas usadas

Essas foram as ferramentas usadas no projeto:

- [ASP.NET](https://dotnet.microsoft.com)
- [PostgreSQL](https://www.postgresql.org/)

## Configuração do Projeto

Siga as etapas abaixo para configurar e executar o projeto:

```bash
    #Clone o repositório
    $ git clone https://github.com/jvolive/DashboardProjects-API.git
```

```bash
    #Entre no repositório
    $ cd DashboardProjects-API
```

```bash
    #Entre na pasta API
    $ cd DashboardProjects-API/src/ProjectsApi.Api
```

```bash
    #Execute o projeto em ASP.NET
    $ dotnet run
```

## Estrutura do Projeto


- **DashboardProjects-API/src/ProjectsApi.Api/Controllers:** Contém os controladores ASP.NET para fornecer APIs e dados ao frontend.
- **DashboardProjects-API/src/ProjectsApi.Application/DTOs:** Define os Data Transfer Objects usados na aplicação.
- **DashboardProjects-API/src/ProjectsApi.Application/Interfaces:** Contém as interfaces usadas pelos serviços da aplicação.
- **DashboardProjects-API/src/ProjectsApi.Application/Services:** Implementa a lógica de negócios da aplicação.
- **DashboardProjects-API/src/ProjectsApi.Infrastructure/Data:** Gerencia o acesso aos dados, incluindo contextos de banco de dados.

## Licença

Este projeto está licenciado sob a [MIT License](./LICENSE).
