# Carpet Stock Management System

A modern admin dashboard for managing carpet inventory built with **Blazor Server** and **Clean Architecture** using **CQRS with MediatR**.

## 🏗️ Architecture

This project follows **Clean Architecture** principles with **CQRS (Command Query Responsibility Segregation)** pattern:

- **Domain Layer** - Core business entities (Carpet)
- **Application Layer** - Commands, Queries, and their handlers using MediatR
- **Infrastructure Layer** - Data access with Entity Framework Core and SQL Server
- **Presentation Layer** - Blazor Server interactive UI

## 🚀 Features

- ✅ **CRUD Operations** for carpets
  - Add new carpets with detailed specifications
  - Update existing carpet information
  - Delete carpets from inventory
  - View all carpets with real-time calculations

- ✅ **Carpet Properties**
  - Name, Description
  - Dimensions (Length × Width in meters)
  - Color and Material
  - Price per square meter
  - Stock quantity tracking
  - Automatic area and total price calculation

- ✅ **Stock Management**
  - Visual stock indicators (badges)
  - Real-time stock totals
  - Stock quantity alerts (color-coded)

## 🛠️ Technology Stack

- **.NET 8.0** - Target framework
- **Blazor Server** - Interactive server-side UI with SignalR
- **MediatR 12.4.1** - CQRS implementation
- **Entity Framework Core 8.0** - ORM for database access
- **SQL Server** - Database (LocalDB for development)
- **Bootstrap 5** - UI styling
- **C# 12** - Programming language

## 📋 Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) or later
- SQL Server LocalDB (comes with Visual Studio) or SQL Server Express
- Visual Studio 2022, VS Code, or Rider (optional)

## 🚀 Getting Started

### 1. Clone the repository
```bash
git clone <your-repo-url>
cd segad-elhmd
```

### 2. Restore dependencies
```bash
dotnet restore
```

### 3. Setup database
The application will automatically create and migrate the database on first run in Development mode.

For manual setup or production deployment, see [DATABASE_SETUP.md](DATABASE_SETUP.md).

### 4. Run the application
```bash
dotnet run --project segad-elhmd/segad-elhmd.csproj
```

### 5. Open in browser
Navigate to: `https://localhost:7104/carpets`

## 📁 Project Structure

```
segad-elhmd/
├── segad-elhmd.sln            # Solution file
├── Domain/                    # Class library - Core entities
│   ├── Entities/
│   │   └── Carpet.cs
│   └── Domain.csproj
├── Application/               # Class library - CQRS Commands & Queries
│   ├── Commands/              # Write operations
│   ├── Queries/               # Read operations
│   ├── DTOs/                  # Data Transfer Objects
│   └── Application.csproj
├── Infrastructure/            # Class library - Data access
│   ├── Data/
│   │   └── AppDbContext.cs    # EF Core DbContext
│   └── Infrastructure.csproj
└── segad-elhmd/               # Blazor Web project
    ├── Components/
    │   ├── Pages/
    │   └── Layout/
    ├── wwwroot/
    └── segad-elhmd.csproj
```

## 🔄 CQRS Pattern

### Commands (Write Operations)
- `CreateCarpetCommand` - Add new carpet
- `UpdateCarpetCommand` - Update existing carpet
- `DeleteCarpetCommand` - Remove carpet

### Queries (Read Operations)
- `GetAllCarpetsQuery` - Retrieve all carpets
- `GetCarpetByIdQuery` - Retrieve single carpet

### Usage in Blazor Pages
```csharp
@inject IMediator Mediator

// Execute query
var carpets = await Mediator.Send(new GetAllCarpetsQuery());

// Execute command
await Mediator.Send(new CreateCarpetCommand(createDto));
```

## 📖 Documentation

- [Architecture Guide](ARCHITECTURE.md) - Detailed architecture overview
- [Database Setup](DATABASE_SETUP.md) - SQL Server configuration and migrations
- [Copilot Instructions](.github/copilot-instructions.md) - AI coding agent guidelines

## 🧪 Adding New Features

### Add a New Query
1. Create query record in `Application/Queries/`
2. Create handler implementing `IRequestHandler<TQuery, TResult>`
3. Use in Blazor: `await Mediator.Send(new YourQuery())`

### Add a New Command
1. Create command record in `Application/Commands/`
2. Create handler implementing `IRequestHandler<TCommand, TResult>`
3. Use in Blazor: `await Mediator.Send(new YourCommand())`

## 🔧 Future Enhancements

- [ ] Add FluentValidation for input validation
- [ ] Add authentication and authorization
- [ ] Implement pagination for large datasets
- [ ] Add search and filtering capabilities
- [ ] Export data to CSV/Excel
- [ ] Add unit and integration tests
- [ ] Implement audit logging
- [ ] Add caching layer (Redis/In-Memory)

## 📝 License

This project is for educational purposes.

## 👤 Author

Your Name

---

**Built with Clean Architecture, CQRS, and MediatR** 🏛️
