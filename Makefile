all: build

build:
	dotnet build

run:
	dotnet run --project src/WebApi
