#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Demo.LoadTesting.Locust/Demo.LoadTesting.Locust.csproj", "Demo.LoadTesting.Locust/"]
RUN dotnet restore "Demo.LoadTesting.Locust/Demo.LoadTesting.Locust.csproj"
COPY . .
WORKDIR "/src/Demo.LoadTesting.Locust"
RUN dotnet build "Demo.LoadTesting.Locust.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Demo.LoadTesting.Locust.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Demo.LoadTesting.Locust.dll"]