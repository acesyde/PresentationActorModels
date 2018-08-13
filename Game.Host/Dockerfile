FROM microsoft/dotnet:2.1-runtime AS base
WORKDIR /app

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY Game.Host/Game.Host.csproj Game.Host/
COPY Game.GrainInterfaces/Game.GrainInterfaces.csproj Game.GrainInterfaces/
COPY Game.Grains/Game.Grains.csproj Game.Grains/
RUN dotnet restore Game.Host/Game.Host.csproj
COPY . .
WORKDIR /src/Game.Host
RUN dotnet build Game.Host.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Game.Host.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Game.Host.dll"]
