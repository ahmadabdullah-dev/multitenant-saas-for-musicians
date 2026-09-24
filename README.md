# Multitenant SaaS for musicians

A platfor that helps musicians manage their work, organize appointments, share content and experiences, promote their works, and build their online presence.

Each musician has their own tenant and can only access their own data securely. The **Super Admin** manages tenants, subscriptions, and packages, with different features available for each package.

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
