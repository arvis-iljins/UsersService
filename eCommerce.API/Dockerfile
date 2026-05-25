# Build stage
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY . .
RUN dotnet publish -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=build /app/publish .

ENV DATABASE_HOST=localhost
ENV DATABASE_NAME=eCommerceDb
ENV DATABASE_USER=arvisiljins
ENV DATABASE_PASSWORD=xxx111
ENV DATABASE_PORT=5432
ENTRYPOINT ["dotnet", "eCommerce.API.dll"]