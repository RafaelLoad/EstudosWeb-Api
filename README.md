# CRUD de Cliente/Estudos

Este projeto é uma aplicação CRUD (Create, Read, Update, Delete) para gerenciar clientes, com uma interface web que consome  API.

# Tecnologias Utilizadas

- ASP.NET Core: Framework para construção da API.
- Entity Framework Core: ORM para manipulação de dados.
- SQL Server: Banco de dados.
- SQL InMemory para testes.
- HTML/₢SS: Interface web para interação com o usuário.
- Dependency Injection: Gerenciamento de dependências.
- EntityFrameworkCore: Mapeamento entre objetos.
- FluentValidation
- JWT (autenticação)
- EF Migration

# Estrutura do Projeto

- API: Diretório contendo a API em ASP.NET Core.
- WebApp: Diretório contendo a aplicação web em HTML/₢SS.
- Data: Diretório contendo a camada de acesso a dados, incluindo o DbContext e as migrações do Entity Framework.

# Configuração do Projeto
- Pré-requisitos
- NET 6 SDK
- SQL Server


# Configure a string de conexão no appsettings.json:

    json
    Copiar código
    {
     "ConnectionStrings":
      {
        "DefaultConnection": "Server=your_server;Database=your_database;User Id=your_username;Password=your_password;"
      }
    }
# Execute as migrações para criar o banco de dados:

 -  visual studio (2022) ou vscode
 - abra o package manager console
 - execute os seguintes comnados
 - add-migration InitialMigration
 - updata-database
 - ira criar o banco automatico


# Endpoints da API
 -  GET /api/clientes: Retorna a lista de clientes.
 -  GET /api/clientes/{id}: Retorna um cliente específico por ID.
 -   POST /api/clientes: Cria um novo cliente.
 -   PUT /api/clientes/{id}: Atualiza um cliente existente.
 -  DELETE /api/clientes/{id}: Exclui um cliente.


 - Se precisar de ajustes ou de mais alguma informação no README, é só avisar!
