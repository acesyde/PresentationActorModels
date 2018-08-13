FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY Game.Api/Game.Api.csproj Game.Api/
COPY Game.GrainInterfaces/Game.GrainInterfaces.csproj Game.GrainInterfaces/
RUN dotnet restore Game.Api/Game.Api.csproj
COPY . .
WORKDIR /src/Game.Api
RUN dotnet build Game.Api.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Game.Api.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Game.Api.dll"]
