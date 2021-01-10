# Criar os projetos

$ dotnet new webapi -o Aplicacao.Api
$ dotnet new classlib -o Aplicacao.Core
$ dotnet new classlib -o Aplicacao.Data
$ dotnet new nunit -o Aplicacao.Tests

# Criar a solution

$ dotnet new sln

# Adicionar os projetos na solution

$ dotnet sln add Aplicacao.Api/Aplicacao.Api.csproj
$ dotnet sln add Aplicacao.Core/Aplicacao.Core.csproj
$ dotnet sln add Aplicacao.Data/Aplicacao.Data.csproj
$ dotnet sln add Aplicacao.Tests/Aplicacao.Tests.csproj

# Dependências do coverlet [Coberrtura de testes]

No módulo Aplicacao.Tests adicionar as dependências para a cobertura de código.

$ dotnet add package coverlet.collector --version 1.3.0
$ dotnet add package coverlet.msbuild --version 2.9.0

No módulo Aplicacao.Api adicionar a referência para o projeto :

$ dotnet add reference ../Aplicacao.Data/Aplicacao.Data.csproj
$ dotnet add reference ../Aplicacao.Core/Aplicacao.Core.csproj
$ dotnet add reference ../Aplicacao.Business/Aplicacao.Business.csproj

No módulo Aplicacao.Business adicionar a referência para o projeto :

$ dotnet add reference ../Aplicacao.Core/Aplicacao.Core.csproj

No módulo Aplicacao.Data adicionar a referência para o projeto :

$ dotnet add reference ../Aplicacao.Core/Aplicacao.Core.csproj
$ dotnet add reference ../Aplicacao.Business/Aplicacao.Business.csproj


