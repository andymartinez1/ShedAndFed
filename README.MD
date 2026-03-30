# ShedAndFed

ShedAndFed is an ASP.NET Core Blazor Server application for tracking reptile care history in one place.  
It is designed to help keepers manage reptile profiles and care logs such as feedings, sheds, and waste events.

## Overview

This project uses a layered architecture to separate UI, business logic, contracts, data access, and domain entities.

Core goals:

- Track each reptile's profile data (species, morph, sex, weight, notes, lifecycle status)
- Maintain a historical log of care events
- Keep the codebase maintainable and easy to extend

From the current implementation:

- Blazor Server app entry point and dependency wiring are in `ShedAndFed.Web/Program.cs`
- Entity Framework Core with SQLite is configured through `ShedAndFed.Data/ReptileDbContext.cs`
- Reptile CRUD service logic is implemented in `ShedAndFed.Services/ReptileService.cs`
- Domain entities are in `ShedAndFed.Entities/*`

## Current Status

Implemented:

- Multi-project solution structure
- EF Core `DbContext` and initial migration
- SQLite persistence (`DefaultConnection` -> `app.db`)
- Reptile service interface and implementation:
    - `AddReptileAsync`
    - `GetReptileByIdAsync`
    - `GetAllReptilesAsync`
    - `UpdateReptileAsync`
    - `DeleteReptileAsync`
- Home page and main layout shell in Blazor components

In progress / next:

- Dedicated routed pages for reptile/log management (`/reptiles`, `/feedings`, `/sheds`, `/wastes`)
- Full UI workflows for creating and viewing logs
- Validation, filtering, and dashboard summaries
- Automated tests

## Tech Stack

- .NET `10.0`
- ASP.NET Core Blazor Server
- Entity Framework Core `10.0.5`
- SQLite

## Solution Architecture

```text
ShedAndFed/
├── ShedAndFed.Web/               # Blazor Server frontend and app host
├── ShedAndFed.Services/          # Business logic and service implementations
├── ShedAndFed.ServiceContracts/  # Service interfaces, DTOs, and enums
├── ShedAndFed.Data/              # EF Core DbContext and migrations
└── ShedAndFed.Entities/          # Domain entities
```

### Project responsibilities

- ShedAndFed.Web
    - App startup and DI registration (Program.cs)
    - Razor components and routes (Components/)
    - Runtime configuration (appsettings.json)

- ShedAndFed.Services
    - Coordinates CRUD operations with logging and error handling

- ShedAndFed.ServiceContracts
    - Public service abstractions and request/response DTOs

- ShedAndFed.Data
    - EF Core context, relationships, and migration history

- ShedAndFed.Entities
    - Core domain objects (Reptile, FeedingLog, ShedLog, WasteLog)

### Relationships:

- One Reptile -> many FeedingLog
- One Reptile -> many ShedLog
- One Reptile -> many WasteLog
- Cascade delete is configured from reptile to associated logs

## Getting Started

### Prerequisites

- NET SDK compatible with target framework `net10.0`
- Git (or)
- Bash shell on Windows (for commands below)

1. **Clone the repository**

```bash
git clone https://github.com/andymartinez1/ShedAndFed.git
```

2. **Navigate to the project directory**

```bash
cd FedAndShed
```

3. **Restore dependencies**

```bash
dotnet restore
```

4. Build and run the app:

```bash
dotnet build
dotnet run
```