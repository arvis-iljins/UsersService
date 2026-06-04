FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ["UsersService.API/UsersService.API.csproj", "UsersService.API/"]
COPY ["UsersService.Core/UsersService.Core.csproj", "UsersService.Core/"]
COPY ["UsersService.Infrastructure/UsersService.Infrastructure.csproj", "UsersService.Infrastructure/"]

RUN dotnet restore "UsersService.API/UsersService.API.csproj"

COPY . .

WORKDIR "/src/UsersService.API"
RUN dotnet build "UsersService.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UsersService.API.csproj" -c Release -o /app/publish --no-restore

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UsersService.API.dll"]
