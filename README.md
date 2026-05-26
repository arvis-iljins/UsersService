# UsersService

Handles user registration, login, and user lookup.

## Stack

- .NET 10
- PostgreSQL + Dapper
- FluentValidation
- AutoMapper

## Run

```bash
cd UsersService.API
dotnet run
```

Swagger: **http://localhost:5025/swagger**

## Environment Variables

| Variable | Default | Description |
|---|---|---|
| `DATABASE_HOST` | localhost | PostgreSQL host |
| `DATABASE_PORT` | 5432 | PostgreSQL port |
| `DATABASE_NAME` | eCommerceDb | Database name |
| `DATABASE_USER` | — | Database user |
| `DATABASE_PASSWORD` | — | Database password |

## Endpoints

| Method | Route | Description |
|---|---|---|
| POST | `/api/auth/login` | Login with email + password |
| POST | `/api/auth/register` | Register a new user |
| GET | `/users/{id}` | Get user by ID |

## Project Structure

```
UsersService/
├── UsersService.API/           # Controllers, middleware, Program.cs
├── UsersService.Core/          # DTOs, entities, services, validators
└── UsersService.Infrastructure/ # Repository, Dapper DB context
```
