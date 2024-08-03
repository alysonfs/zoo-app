/zoo-app-monorepo
  /src
    /ZooApp.WebAPI             # Projeto .NET Core WebAPI para o backend
    /ZooApp.Frontend           # Aplicação Angular para o frontend
    /zoo-app.sln                # Solução .NET para os projetos dentro de src
  /tests
    /ZooApp.WebAPITests        # Testes para o projeto .NET Core WebAPI usando NUnit
  /docs                        # Documentação do projeto
  /scripts                     # Scripts úteis para build, deploy, etc.
  README.md                    # Documentação inicial do monorepo
  .gitignore                   # Configurações do Git para ignorar arquivos/diretórios
  zoo-app-monorepo.sln         # Solução principal que referencia os projetos individuais

------------------------------------------------------

Project 'ZooApp.WebAPITests' has the following package references
   [net8.0]: 
   Top-level Package             Requested   Resolved
   > coverlet.collector          6.0.0       6.0.0   
   > Microsoft.NET.Test.Sdk      17.8.0      17.8.0  
   > NUnit                       3.14.0      3.14.0  
   > NUnit.Analyzers             3.9.0       3.9.0   
   > NUnit3TestAdapter           4.5.0       4.5.0   

Project 'ZooApp.WebAPI' has the following package references
   [net8.0]: 
   Top-level Package                   Requested   Resolved
   > Microsoft.AspNetCore.OpenApi      8.0.6       8.0.6   
   > Swashbuckle.AspNetCore            6.4.0       6.4

------------------------------------------------------

Angular CLI: 18.1.3
Node: 20.16.0
Package Manager: npm 10.8.1
OS: darwin x64

Angular: 
... 

Package                      Version
------------------------------------------------------
@angular-devkit/architect    0.1801.3 (cli-only)
@angular-devkit/core         18.1.3 (cli-only)
@angular-devkit/schematics   18.1.3 (cli-only)
@schematics/angular          18.1.3 (cli-only)


------------------------------------------------------
Adicionar certificado SSL para desenvolvimento
dotnet dev-certs https --trust