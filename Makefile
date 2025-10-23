all: build

build:
	dotnet build

run:
	dotnet run --project src/WebApi

publish:
	dotnet publish src/WebApi --configuration Release --self-contained true --output C:/Workspaces/Tools/Whistler

install:
	sudo sc.exe create "Whistler" binpath= "C:\Workspaces\Tools\Whistler\Whistler.WebApi.exe"

uninstall:
	sudo sc.exe delete "Whistler"

start:
	sudo sc.exe start "Whistler"

stop:
	sudo sc.exe stop "Whistler"
