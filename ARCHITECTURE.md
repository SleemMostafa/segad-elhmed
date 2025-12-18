# Architecture Summary - CQRS with MediatR

## 🏗️ Project Structure

```
segad-elhmd/
├── segad-elhmd.sln                      # Solution file
│
├── Domain/                              # Class Library Project
│   ├── Entities/
│   │   └── Carpet.cs                    # Business entity with calculated properties
│   └── Domain.csproj
│
├── Application/                         # Class Library Project
│   ├── Commands/                        # WRITE operations
│   │   ├── CreateCarpetCommand.cs
│   │   ├── CreateCarpetCommandHandler.cs
│   │   ├── UpdateCarpetCommand.cs
│   │   ├── UpdateCarpetCommandHandler.cs
│   │   ├── DeleteCarpetCommand.cs
│   │   └── DeleteCarpetCommandHandler.cs
│   ├── Queries/                         # READ operations
│   │   ├── GetAllCarpetsQuery.cs
│   │   ├── GetAllCarpetsQueryHandler.cs
│   │   ├── GetCarpetByIdQuery.cs
│   │   └── GetCarpetByIdQueryHandler.cs
│   ├── DTOs/
│   │   ├── CarpetDto.cs
│   │   ├── CreateCarpetDto.cs
│   │   └── UpdateCarpetDto.cs
│   └── Application.csproj               # References: Domain, MediatR
│
├── Infrastructure/                      # Class Library Project
│   ├── Data/
│   │   └── AppDbContext.cs              # EF Core DbContext for SQL Server
│   └── Infrastructure.csproj            # References: Domain, EF Core SQL Server
│
└── segad-elhmd/                         # Blazor Web Project
    ├── Components/
    │   ├── Pages/
    │   │   ├── Carpets.razor            # List + Delete (Query + Command)
    │   │   ├── CreateCarpet.razor       # Create (Command)
    │   │   └── EditCarpet.razor         # Get + Update (Query + Command)
    │   └── Layout/
    ├── wwwroot/
    └── segad-elhmd.csproj               # References: Application, Infrastructure
```

## 🔄 Request Flow

### Query Example (Read)
```
Carpets.razor
    ↓ await Mediator.Send(new GetAllCarpetsQuery())
MediatR
    ↓ routes to
GetAllCarpetsQueryHandler
    ↓ injects
AppDbContext (EF Core)
    ↓ queries SQL Server
    ↓ returns
List<CarpetDto>
```

### Command Example (Write)
```
CreateCarpet.razor
    ↓ await Mediator.Send(new CreateCarpetCommand(dto))
MediatR
    ↓ routes to
CreateCarpetCommandHandler
    ↓ creates entity
    ↓ saves to
AppDbContext (EF Core)
    ↓ persists to SQL Server
    ↓ returns
CarpetDto
```

## ✅ Key Benefits

1. **No Repository Interfaces** - MediatR handles request routing
2. **Single Responsibility** - One handler per operation
3. **Testable** - Each handler can be tested independently
4. **Scalable** - Easy to add new commands/queries
5. **Clear Separation** - Reads vs Writes are explicit

## 📦 Dependencies

- **MediatR** 12.4.1 - Request/response mediator pattern
- **Entity Framework Core** 8.0.11 - ORM for database access
- **SQL Server** - Database provider (LocalDB for development)
- **.NET 8.0** - Target framework
- **Blazor Server** - Interactive UI with SignalR

## 🚀 How to Add New Operations

### Add a Search Query
1. Create `Application/Queries/SearchCarpetsByColorQuery.cs`:
   ```csharp
   public record SearchCarpetsByColorQuery(string Color) : IRequest<IEnumerable<CarpetDto>>;
   ```

2. Create handler `SearchCarpetsByColorQueryHandler.cs`:
   ```csharp
   public class SearchCarpetsByColorQueryHandler : IRequestHandler<SearchCarpetsByColorQuery, IEnumerable<CarpetDto>>
   {
       private readonly AppDbContext _context;
       // implementation with LINQ query
   }
   ```

3. Use in Blazor:
   ```razor
   var results = await Mediator.Send(new SearchCarpetsByColorQuery("Red"));
   ```

### Add an Update Stock Command
1. Create `Application/Commands/UpdateStockCommand.cs`
2. Create `UpdateStockCommandHandler.cs`
3. Use: `await Mediator.Send(new UpdateStockCommand(id, newQuantity));`

## 🗄️ Database

**Provider:** SQL Server with Entity Framework Core

**Setup:**
- Development: SQL Server LocalDB (`SegadElhmdDb_Dev`)
- Production: Configurable SQL Server instance
- Migrations: Automatic in development, manual in production

See [DATABASE_SETUP.md](DATABASE_SETUP.md) for detailed instructions.

**DbContext Configuration:**
- Carpets table with proper constraints
- Computed properties (Area, TotalPrice) excluded from database
- Decimal precision for prices: `decimal(18,2)`

## ✅ Project Dependencies

**Clean Architecture Dependency Flow:**
```
segad-elhmd (Web) ──┬──> Application ──> Domain
                    └──> Infrastructure ──> Domain
```

**Project References:**
- `Domain.csproj` - **No dependencies** (pure business logic)
- `Application.csproj` - References: `Domain`, `MediatR` NuGet package
- `Infrastructure.csproj` - References: `Domain`, `Microsoft.EntityFrameworkCore.SqlServer`, `Microsoft.EntityFrameworkCore.Tools`
- `segad-elhmd.csproj` (Web) - References: `Application`, `Infrastructure`, `MediatR`

**Namespaces:**
- Domain entities: `Domain.Entities`
- Application layer: `Application.Commands`, `Application.Queries`, `Application.DTOs`
- Infrastructure: `Infrastructure.Data`
- Web layer: `segad_elhmd.Components` (kept for compatibility)

---
**No service layer, no repository interfaces - just Commands, Queries, and Handlers!**
