# Whistler

```powershell
dotnet new sln --formal slnx --name Whistler
```

```powershell
dotnet new webapi --framework net9.0 --no-https --use-program-main --use-controllers --output src/WebApi --name Whistler.WebApi
dotnet sln add src/WebApi
dotnet add src/WebApi package Microsoft.Extensions.Hosting.WindowsServices
```

```powershell
dotnet new classlib --framework net9.0 --output src/Domain --name Whistler.Domain
dotnet sln add src/Domain
dotnet new classlib --framework net9.0 --output src/Application --name Whistler.Application
dotnet sln add src/Application
dotnet add src/Application reference src/Domain
dotnet new classlib --framework net9.0 --output src/Infrastructure --name Whistler.Infrastructure
dotnet sln add src/Infrastructure
dotnet add src/Infrastructure reference src/Application
dotnet add src/WebApi reference src/Infrastructure
```

```powershell
dotnet add src/Application package MediatR
dotnet add src/Infrastructure package Microsoft.Extensions.Configuration.Binder
```

## Unit Tests

```powershell
dotnet new mstest --output tests/Domain.UnitTests --name Whistler.Domain.UnitTests
dotnet sln add tests/Domain.UnitTests
dotnet add tests/Domain.UnitTests reference src/Domain
dotnet add tests/Domain.UnitTests package Shouldly
```

```powershell
dotnet new mstest --output tests/Application.UnitTests --name Whistler.Application.UnitTests
dotnet sln add tests/Application.UnitTests
dotnet add tests/Application.UnitTests reference src/Application
dotnet add tests/Application.UnitTests package NSubstitute 
dotnet add tests/Application.UnitTests package Shouldly
```

## Functional Tests

```powershell
dotnet new mstest --output tests/Application.FunctionalTests --name Whistler.Application.FunctionalTests
dotnet sln add tests/Application.FunctionalTests
dotnet add tests/Application.FunctionalTests reference src/Infrastructure
dotnet add tests/Application.FunctionalTests package Microsoft.Extensions.Configuration
dotnet add tests/Application.FunctionalTests package Microsoft.Extensions.DependencyInjection
dotnet add tests/Application.FunctionalTests package Microsoft.Extensions.Logging
dotnet add tests/Application.FunctionalTests package Microsoft.Extensions.TimeProvider.Testing
dotnet add tests/Application.FunctionalTests package Shouldly
```

## End to End Tests

```powershell
dotnet new mstest --output tests/WebApi.EndToEndTests --name Whistler.WebApi.EndToEndTests
dotnet sln add tests/WebApi.EndToEndTests
dotnet add tests/WebApi.EndToEndTests reference src/WebApi
dotnet add tests/WebApi.EndToEndTests package Microsoft.AspNetCore.Mvc.Testing
dotnet add tests/WebApi.EndToEndTests package Shouldly
```

```powershell
dotnet publish src/WebApi --configuration Release --self-contained true --output C:/Workspaces/Tools/Whistler
```

```powershell
sudo sc.exe create "Whistler" binpath= "C:\Workspaces\Tools\Whistler\Whistler.WebApi.exe"
sudo sc.exe start "Whistler"
sudo sc.exe stop "Whistler"
sudo sc.exe delete "Whistler"
```