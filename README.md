# Tadriby Coach

- A multi-tenant SaaS platform for personal trainers to manage their clients, organize appointments, create training plans, and manage their coaching business.
- Each personal trainer has their own tenant and can securely access only their own data and clients. 
- The Super Admin manages trainers, subscriptions, platform and more.

## Tech Stack
- **WEB:** React, TypeScript, TanStack Query, Axios, MUI, React Router
- **API:** ASP.NET Web API, C#
- **Auth:** ASP.NET Identity, Cookie-based Authentication, Role-based Authorization
- **ORM:** Entity Framework, Code First, BaseEntity

## Features 
- EmailService
- DataSeeder
- RateLimiter
- Cors
- AuthService (Login, Logout)

## Architechure(Layered On API)
- **WEB:** UI Components, Hooks, Routes, Call APIs
- **API:** Controllers, BaseApiController, CORS, UserSecrets, RateLimiter, GlobalUsings, AppCookie Configuration, Policies, DI per layer
- **Application:** Services, Interfaces, Dtos, Result<T> Pattern, Global Usings, IOptions for Configurations, DI per layer, GlobalUsings
- **Infrastructure:** Repositories, Interfaces, BaseRepository, PagedList, DataSeeder, AppDbContext, DI per layer, GlobalUsings
- **Domain:** BaseEntity, Entities, GlobalUsings

## Run Database Migrations

Run these commands from the **solution root**.

**Add a migration:**

```powershell
dotnet ef migrations add Mig_1 --project .\Infrastructure\Infrastructure.csproj --startup-project .\API\API.csproj
```

**Apply migrations:**

```powershell
dotnet ef database update --project .\Infrastructure\Infrastructure.csproj --startup-project .\API\API.csproj
```
