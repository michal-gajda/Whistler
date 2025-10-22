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

```powershell
dotnet publish src/WebApi --configuration Release --self-contained true --output C:/Workspaces/Tools/Whistler
```

```powershell
sudo sc.exe create "Whistler" binpath= "C:\Workspaces\Tools\Whistler\Whistler.WebApi.exe"
sudo sc.exe start "Whistler"
sudo sc.exe stop "Whistler"
sudo sc.exe delete "Whistler"
```